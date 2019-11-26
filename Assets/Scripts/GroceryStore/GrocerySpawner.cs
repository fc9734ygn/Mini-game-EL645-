using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrocerySpawner : MonoBehaviour
{
    public float spawnIntervalInSeconds; 
    public float dropSpeed; 
    public float maxX; 
    public float minX;

    private Object[] groceries;

    void Start()
    {
        groceries = Resources.LoadAll("Prefab/Groceries", typeof(GameObject));
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnIntervalInSeconds);

        System.Random random = new System.Random();
        int randomIndex = random.Next(groceries.Length - 1);
        GameObject prefab = groceries[randomIndex] as GameObject;

        GameObject spawnedObject = Instantiate(prefab, new Vector3(Random.Range(minX, maxX), transform.position.y, 0f), Quaternion.Euler(0, 0, 0)) as GameObject;
        spawnedObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -dropSpeed));

        StartCoroutine("Spawn");
    }
}
