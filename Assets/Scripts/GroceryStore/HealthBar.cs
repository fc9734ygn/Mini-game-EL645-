using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Sprite hpFull;
    public Sprite hpEmpty;

    public Image icon0;
    public Image icon1;
    public Image icon2;
    public GameObject sceneController;
    public GameObject spawner;

    public int currentHealth;

    private int MAX_HEALTH = 3;

    private void Update()
    {
        UpdateHUD();
    }

    public void DealDamage(int amount)
    {
        if(currentHealth > 0)
        {
            currentHealth = currentHealth - amount;
            Animate();
        }
       
        if (currentHealth < 1)
        {
            DeleteMidAirGroceries();
            spawner.SetActive(false);
            sceneController.GetComponent<SceneController>().LoadKitchenScene();
        }
    }

    private void DeleteMidAirGroceries()
    {
        GameObject[] midAirGroceries = GameObject.FindGameObjectsWithTag("Grocery");
        foreach (GameObject grocery in midAirGroceries)
        {
            Destroy(grocery);
        }
    }

    private void Animate()
    {
          StartCoroutine(ShakeAnimation(transform.position));
    }

    private IEnumerator ShakeAnimation(Vector3 originalPos)
    {
        var countDown = 0.5f;
        for (int i = 0; i < 10000; i++)
        {
            while (countDown >= 0)
            {
                var speed = 25;
                var posStart = originalPos + new Vector3(0, 0.05f, 0);
                var posEnd = originalPos + new Vector3(0, -0.05f, 0);
                countDown -= Time.smoothDeltaTime;
                transform.position = Vector3.Lerp(posStart, posEnd, Mathf.PingPong(Time.time * speed, 1.0f));
                yield return null;
            }
        }
    }

    public void Heal(int amount)
    {
        if (currentHealth + amount > MAX_HEALTH)
        {
            currentHealth = MAX_HEALTH;
        }
        else
        {
            currentHealth = currentHealth + amount;
        }
    }

    private void UpdateHUD()
    {
        switch (currentHealth)
        {
            case 0:
                icon0.sprite = hpEmpty;
                icon1.sprite = hpEmpty;
                icon2.sprite = hpEmpty;
                break;
            case 1:
                icon0.sprite = hpFull;
                icon1.sprite = hpEmpty;
                icon2.sprite = hpEmpty;
                break;
            case 2:
                icon0.sprite = hpFull;
                icon1.sprite = hpFull;
                icon2.sprite = hpEmpty;
                break;
            case 3:
                icon0.sprite = hpFull;
                icon1.sprite = hpFull;
                icon2.sprite = hpFull;
                break;
            default:
                break;
        }
    }
}
