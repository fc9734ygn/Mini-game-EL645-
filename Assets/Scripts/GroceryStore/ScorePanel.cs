using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    int score = 0;
    public void SetScore(int collectedAmount)
    {
        score = collectedAmount;
        gameObject.GetComponent<TextMeshProUGUI>().SetText("Collected: " + score);
    }
}
