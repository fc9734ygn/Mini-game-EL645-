using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spawn_items : MonoBehaviour
{
    private float spawnTime = 3;
    public readonly int upForce = 680; // Up force
    public readonly int leftRightForce = 180; // Left and right force
    private readonly int gravity = 1;
    private readonly int maxX = 9; // Max x spawn position
    private readonly int minX = -9; // Min x spawn position
    private int count = 0;
    public GameObject flySpawner;
    public GameObject cockroach;
    public GameObject sceneManager;
    // List of collected groceries
    private List<GameObject> collectedGroceries;
    // List because unity editor don't support dictionaries
    [SerializeField] public List<GroceryEntry> groceryPrefab;
    // Used to map grocery types to corresponding sprites
    private Dictionary<Grocery.GroceryType, GameObject> groceryPrefabLookup;
    [Serializable]
    public class GroceryEntry
    {
        public Grocery.GroceryType type;
        public GameObject prefab;
    }
    void Awake()
    {
        AssignPrefabs();
    }
    void Start()
    {
        collectedGroceries = new List<GameObject> { };

        foreach (Grocery.GroceryType grocery in Basket.collectedGroceries)
        {
            collectedGroceries.Add(groceryPrefabLookup[grocery]);
        }

        StartCoroutine("Spawn");
    }
    IEnumerator Spawn()
    {
        // Wait spawnTime
        yield return new WaitForSeconds(spawnTime);

        //Increase spawned grocery count
        count++;

        // If count is less or equal to grocery list length then spawn the next grocery
        if (count <= collectedGroceries.Count)
        {


            // Add gravity
            collectedGroceries[count - 1].GetComponent<Rigidbody2D>().gravityScale = gravity;

            // Spawn grocery add random position
            GameObject go = Instantiate(collectedGroceries[count - 1], new Vector3(UnityEngine.Random.Range(minX
            , maxX + 1), transform.position.y, 0f), Quaternion.Euler(0, 0, 0)) as GameObject;

            // If x position is over 0 go left
            if (go.transform.position.x > 0)
            {
                go.GetComponent<Rigidbody2D>().AddForce(new Vector2(-
                leftRightForce, upForce));
            }
            // Else go right
            else
            {
                go.GetComponent<Rigidbody2D>().AddForce(new Vector2(leftRightForce, upForce));
            }

            // Increase the difficulty of the second scene
            IncreaseDifficulty2();


            // Start the spawn again
            StartCoroutine("Spawn");
        }
        else
        {
            // Wait for last grocery
            yield return new WaitForSeconds(2);
            // Game over screen
            sceneManager.GetComponent<SceneController>().LoadGameOver();
        }
    }
    // Increase difficulty
    private void IncreaseDifficulty2()
    {
        switch (count)
        {
            case 5:
                // Spawn flies
                Instantiate(flySpawner, new Vector3(0, 0, 0),
                Quaternion.identity);
                break;
            // Decrease spawning time
            case 10:
                spawnTime = 2.5f;
                break;
                // Decrease spawning time
            case 25:
                spawnTime = 2;
                break;
                // Destroy flies
            case 35:
                GameObject[] flies;
                flies = GameObject.FindGameObjectsWithTag("Fly");
                if (flies.Length > 0)
                {
                    foreach (GameObject go in flies)
                    {
                        Destroy(go);
                    }
                }
                break;
                // Spawn coackroach
            case 36:
                Instantiate(cockroach, new Vector3(0, 50, 0),
                                    Quaternion.identity);
                break;
                // Decrease spawning time
            case 40:
                spawnTime = 1.5f;
                break;
            case 50:
                spawnTime = 1.2f;
                break;

        }
    }
    // Assigns the prefabs in the Dictionary
    private void AssignPrefabs()
    {
        groceryPrefabLookup = new Dictionary<Grocery.GroceryType, GameObject>();

        foreach (GroceryEntry entry in groceryPrefab)
        {
            groceryPrefabLookup.Add(entry.type, entry.prefab);
        }
    }

}
