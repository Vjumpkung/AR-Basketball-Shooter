using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDiff : MonoBehaviour
{
    DiffController diffController;
    void Start()
    {
        diffController = GetComponent<DiffController>();
        diffController.Difficulty = StateNameController.difficulty;
    }

    public void setDifficulty(string  difficulty)
    {
        diffController.Difficulty = difficulty;
        StateNameController.difficulty = difficulty;
    }
}
