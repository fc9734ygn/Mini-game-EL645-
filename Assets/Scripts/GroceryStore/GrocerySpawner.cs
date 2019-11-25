using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrocerySpawner : MonoBehaviour
{
    public GameObject onion, bacon, banana, carrot, detergent, oil, tomato, waterBottle;
    private List<GameObject> prefabs;
    public float spawnIntervalInSeconds; 
    public float dropSpeed; 
    public float maxX; 
    public float minX; 

    void Start()
    {
        //Start the spawn update
        StartCoroutine("Spawn");
        prefabs = new List<GameObject> { onion, bacon, banana, carrot, detergent, oil, tomato, waterBottle};
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnIntervalInSeconds);

        System.Random random = new System.Random();
        int randomIndex = random.Next(prefabs.Count);
        GameObject prefab = prefabs[randomIndex];


        GameObject spawnedObject = Instantiate(prefab, new Vector3(Random.Range(minX, maxX), transform.position.y, 0f), Quaternion.Euler(0, 0, 0)) as GameObject;
        spawnedObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -dropSpeed));

        //Start the spawn again
        StartCoroutine("Spawn");
    }
}
