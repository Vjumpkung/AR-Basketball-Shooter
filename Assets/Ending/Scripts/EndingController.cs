using TMPro;
using UnityEngine;

public class EndingController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI attempt;
    [SerializeField] TextMeshProUGUI grade;
    
    void Start()
    {
        score.text = StateNameController.score.ToString();
        attempt.text = StateNameController.attempt.ToString();

        if (StateNameController.score >= StateNameController.targetScore)
        {
            grade.text = "PASS";
            grade.color = new Color(0, 0.8f, 0, 255);
        }
        else
        {
            grade.text = "FAIL";
        }
    }
}
