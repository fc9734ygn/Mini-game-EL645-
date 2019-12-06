using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoresText : MonoBehaviour
{
    public GameObject highscoresController;
    
    void Start()
    {
        int highscore = highscoresController.GetComponent<HighscoresController>().GetHighscore();
        GetComponent<TextMeshProUGUI>().SetText(Constants.HIGHSCORES_TEXT + highscore);
    }
}
