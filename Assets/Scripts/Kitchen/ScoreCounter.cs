using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int score = 0;

    private void Start()
    {
        SetScore(score);
    }

    public void SetScore(int newScore)
    {
        score = newScore;
        gameObject.GetComponent<TextMeshProUGUI>().SetText("Score: " + score);
    }

  
}
