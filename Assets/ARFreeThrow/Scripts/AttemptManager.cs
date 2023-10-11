using TMPro;
using UnityEngine;

public class AttemptManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextScoreUI;

    private int _attempt;

    public int Attempt
    {
        get { return _attempt; }
        set
        {
            _attempt = value;

            TextScoreUI.text = Attempt.ToString();

            PlayerPrefs.SetInt("Attempt : ", Attempt);
        }
    }
}
