using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        if (StateNameController.maxAttempt != 0 && StateNameController.attempt >= StateNameController.maxAttempt)
        {
            InputAxesAndSceneChanges.LoadScene("Ending");
        }
    }
}
