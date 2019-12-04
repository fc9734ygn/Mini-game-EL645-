using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    private int score = 0;
    private int difficultyIndex = 0;

    public GameObject spawner;

    public void SetScore(int collectedAmount)
    {
        score = collectedAmount;
        gameObject.GetComponent<TextMeshProUGUI>().SetText("Collected: " + score);
        UpdateDifficulty();
    }

    private void UpdateDifficulty()
    {
        difficultyIndex++;
        if (difficultyIndex == 10)
        {
            spawner.GetComponent<GrocerySpawner>().IncreaseDifficulty();
            difficultyIndex = 0;
        }
    }
}
