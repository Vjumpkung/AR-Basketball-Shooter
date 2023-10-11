using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiffManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI diffText;
    [SerializeField] TextMeshProUGUI descText;
    void Start()
    {
        diffText.text = StateNameController.difficulty;
        if (StateNameController.difficulty == "Easy")
        {
            descText.text = "Target Score 20\nMaximum Attempt : 20";
            StateNameController.targetScore = 20;
            StateNameController.maxAttempt = 20;
        }
        else if (StateNameController.difficulty == "Normal")
        {
            descText.text = "Target Score 30\nMaximum Attempt : 15";
            StateNameController.targetScore = 30;
            StateNameController.maxAttempt = 15;
        }
        else if(StateNameController.difficulty == "Hard")
        {
            descText.text = "Target Score 40\nMaximum Attempt : 10";
            StateNameController.targetScore = 40;
            StateNameController.maxAttempt = 10; 
        }
    }
}
