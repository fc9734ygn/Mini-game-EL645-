using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Flies : MonoBehaviour
{
    public float spawnIntervalInSeconds=3;
    private int count;

    public GameObject fly;


    void Start()
    {
        count = 0;
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnIntervalInSeconds);
        count++;
        if (count < 2)
        {
            GameObject spawnedObject = Instantiate(fly, new Vector3(-3 + Random.Range(-0.5f, 0.5f), 2 +Random.Range(-0.5f, 0.5f), 0f), Quaternion.Euler(0, 0, 0)) as GameObject;
            StartCoroutine("Spawn");

        }
        else if (count < 3)
        {
            GameObject spawnedObject = Instantiate(fly, new Vector3(3 + Random.Range(-0.5f, 0.5f), 2 + Random.Range(-0.5f, 0.5f), 0f), Quaternion.Euler(0, 0, 0)) as GameObject;
            StartCoroutine("Spawn");

        }
        else
        {
            GameObject spawnedObject = Instantiate(fly, new Vector3(Random.Range(-0.5f, 0.5f), -2 + Random.Range(-0.5f, 0.5f), 0f), Quaternion.Euler(0, 0, 0)) as GameObject;

        }
    }

}

