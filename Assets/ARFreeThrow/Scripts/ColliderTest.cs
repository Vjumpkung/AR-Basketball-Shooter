using UnityEngine;

public class ColliderTest : MonoBehaviour
{
    private bool isEnter = false;
    private bool isExit = false;
    static private int points = 0;

    ScoreManager scoreManager;

    private void Start()
    {
        points = 0;
        StateNameController.score = points;
        scoreManager = FindAnyObjectByType<ScoreManager>();
        scoreManager.Score = 0;

    }
    private void Update()
    {
        if (isEnter && isExit)
        {
            isEnter = false;
            isExit = false;
            points = points + (int)Mathf.Round(PlaceHoop.HoopDistance);
            StateNameController.score = points;
            scoreManager.Score = points;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnterHoop" && BallControl.isThrow)
        {
            isEnter = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "EnterHoop" && BallControl.isThrow)
        {
            isExit = true;
        }
    }

}
