using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public HighscoresController highscoresController;
    public GameObject scorePanel;
    public GameObject newHighscorePanel;


    void Start()
    {
        int score = PlayerController.scoreCount;
        int highscore = highscoresController.GetHighscore();
        TextMeshProUGUI scoreText = scorePanel.GetComponent<TextMeshProUGUI>();
        
        if(score > highscore)
        {
            newHighscorePanel.SetActive(true);
            highscoresController.SetHighscore(score);
        }
        else
        {
            newHighscorePanel.SetActive(false);
        }
        scoreText.SetText("Your score: " + score);
    }

}
