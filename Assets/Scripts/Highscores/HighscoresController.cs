using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoresController : MonoBehaviour
{
    public int GetHighscore()
    {
        return PlayerPrefs.GetInt(Constants.PLAYER_PREF_HIGHSCORE_KEY, 0);
    }

    public void SetHighscore(int score)
    {
        var currentHighscore = PlayerPrefs.GetInt("Score", 0);
        if (score > currentHighscore)
        {
            PlayerPrefs.SetInt(Constants.PLAYER_PREF_HIGHSCORE_KEY, score);
        }
    }
}
