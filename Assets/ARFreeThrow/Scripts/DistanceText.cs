using UnityEngine;
using TMPro;

public class DistanceText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextDistanceUI; 

    private float _dis;

    public float Distance
    {
        get { return _dis; }
        set { 
            _dis = value; 
        
            TextDistanceUI.text = Distance.ToString();

            PlayerPrefs.SetFloat("Distance : ", Distance);
        }
    }
}
