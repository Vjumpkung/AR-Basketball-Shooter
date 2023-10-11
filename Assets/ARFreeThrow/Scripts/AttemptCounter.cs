using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttemptCounter : MonoBehaviour
{
    private static int counter = 0;
    
    public void ResetCounter()
    {
        counter = -1;
    }

    public void IncreaseCounter()
    {
        counter++;
        StateNameController.attempt = counter;
    }

    public int GetCounter()
    {
        return counter;
    }

    public void printCounter()
    {
        Debug.Log(counter);
    }
}
