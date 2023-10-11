using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceHoop : MonoBehaviour
{
    static public float HoopDistance;

    private List<GameObject> placedObjects = new List<GameObject>();

    [SerializeField]
    GameObject m_PlanePrefab;

    public GameObject placedPlane
    {
        get { return m_PlanePrefab; }
        set { m_PlanePrefab = value; }
    }

    public GameObject spawnedPlane { get; private set; }

    [SerializeField]
    [Tooltip("Instantiates this hoop prefab on a plane at the touch location.")]
    GameObject m_HoopPrefab;

    /// <summary>
    /// The prefab to instantiate on touch.
    /// </summary>
    public GameObject placedHoop
    {
        get { return m_HoopPrefab; }
        set { m_HoopPrefab = value; }
    }

    /// <summary>
    /// The object instantiated as a result of a successful raycast intersection with a plane.
    /// </summary>
    public GameObject spawnedHoop { get; private set; }

    [SerializeField]
    [Tooltip("Instantiates this ball prefab in front of the AR Camera.")]
    GameObject m_BallPrefab;

    /// <summary>
    /// The prefab to instantiate on touch.
    /// </summary>
    public GameObject placedBall
    {
        get { return m_BallPrefab; }
        set { m_BallPrefab = value; }
    }

    /// <summary>
    /// The object instantiated as a result of a successful raycast intersection with a plane.
    /// </summary>
    public GameObject spawnedBall { get; private set; }

    /// <summary>
    /// Invoked whenever an object is placed in on a plane.
    /// </summary>
    public static event Action onPlacedObject;

    private bool isPlaced = false;

    ARRaycastManager m_RaycastManager;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    DistanceText distanceText;

    private void Start()
    {
        distanceText = FindObjectOfType<DistanceText>();

        distanceText.Distance = 0;

    }

    void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (isPlaced)
        {
            distanceCalculator();
            return;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (m_RaycastManager.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = s_Hits[0].pose;

                    spawnedPlane = Instantiate(m_PlanePrefab, hitPose.position, Quaternion.AngleAxis(180, Vector3.up));
                    spawnedPlane.transform.parent = transform;
                    placedObjects.Add(spawnedPlane);

                    Vector3 yOffset = new Vector3(0f, 1.25f, 0f);
                    hitPose.position += yOffset;

                    Quaternion hoopRotation = hitPose.rotation * Quaternion.Euler(0, -90, 0);
                    spawnedHoop = Instantiate(m_HoopPrefab, hitPose.position, hoopRotation);
                    spawnedHoop.transform.parent = transform.parent;
                    placedObjects.Add(spawnedHoop);

                    isPlaced = true;

                    spawnedBall = Instantiate(m_BallPrefab);
                    // spawnedBall.transform.parent = m_RaycastManager.transform.Find("Main Camera").gameObject.transform;
                    placedObjects.Add(spawnedBall);

                    if (onPlacedObject != null)
                    {
                        onPlacedObject();
                    }
                }
            }
        }
    }

    public void distanceCalculator()
    {
        Transform cameraTransform = Camera.main.transform;
        Vector3 cameraPosition = cameraTransform.position;
        float distance = Vector3.Distance(cameraPosition, spawnedHoop.transform.position);
        HoopDistance = distance;
        distanceText.Distance = HoopDistance;
        // Debug.Log(distance);
    }

    public void ResetARSession()
    {
        distanceText.Distance = 0;
        isPlaced = false;

        // Destroy all placed objects.
        foreach (GameObject obj in placedObjects)
        {
            Destroy(obj);
        }

        placedObjects.Clear();

        BallControl.attemptCounter.ResetCounter();

        ARSession aRSession = FindObjectOfType<ARSession>();
        aRSession.Reset();
    }

}