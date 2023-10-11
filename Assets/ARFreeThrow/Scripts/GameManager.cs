using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        if (StateNameController.attempt > StateNameController.maxAttempt)
        {
            InputAxesAndSceneChanges.LoadScene("Ending");
        }
    }
}
