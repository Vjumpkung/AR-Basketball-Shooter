using TMPro;
using UnityEngine;

public class DiffController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI DifficultyDisplay;

    private string _diff;

    public string Difficulty 
    {  
        get { return _diff; }
        set
        {
            _diff = value;

            DifficultyDisplay.text = Difficulty;

            PlayerPrefs.SetString("",Difficulty);
        }
    }
}
