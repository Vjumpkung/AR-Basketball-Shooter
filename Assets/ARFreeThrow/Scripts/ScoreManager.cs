using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextScoreUI;

    private int _score;
     
    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;

            TextScoreUI.text = Score.ToString();

            PlayerPrefs.SetInt("Score : ", Score);
        }
    }
}
