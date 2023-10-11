using UnityEngine;

public class StateNameController : MonoBehaviour
{
    public static string difficulty = "Easy";
    public static int score = 0;
    public static int attempt = 0;
    public static int targetScore = 0;
    public static int maxAttempt = 0;

    public static void GameReset()
    {
        score = 0;
        attempt = 0;
        targetScore = 0;
        maxAttempt = 0;
    }
}
