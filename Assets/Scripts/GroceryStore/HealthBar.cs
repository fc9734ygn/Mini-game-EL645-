using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Sprite heartFull;
    public Sprite hearthEmpty;

    public Image heart0;
    public Image heart1;
    public Image heart2;

    public int currentHealth;

    private void Update()
    {
        UpdateHUD();
    }

    public void DealDamage()
    {
        currentHealth--;
        if (currentHealth < 1)
        {
            //TODO: die
        }
    }

    public void Heal()
    {
        if (currentHealth < 3)
        {
            currentHealth++;
        }
    }

    private void UpdateHUD()
    {
        switch (currentHealth)
        {
            case 0:
                heart0.sprite = hearthEmpty;
                heart1.sprite = hearthEmpty;
                heart2.sprite = hearthEmpty;
                break;
            case 1:
                heart0.sprite = heartFull;
                heart1.sprite = hearthEmpty;
                heart2.sprite = hearthEmpty;
                break;
            case 2:
                heart0.sprite = heartFull;
                heart1.sprite = heartFull;
                heart2.sprite = hearthEmpty;
                break;
            case 3:
                heart0.sprite = heartFull;
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                break;
            default:
                break;
        }
    }
}
