using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_items : MonoBehaviour
{
    public float spawnTime= 1;

    public float upForce = 680; //Up force
    public float leftRightForce = 180; //Left and right force
    public float gravity = 1;
    public float maxX = 9; //Max x spawn position
    public float minX = -9; //Min x spawn position
    private int count = 0;
    public GameObject flySpawner;

    private Object[] collectedGroceries;

    void Start()
    {
        collectedGroceries = Resources.LoadAll("Prefab/Groceries", typeof(GameObject));
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        // Wait spawnTime
        yield return new WaitForSeconds(spawnTime);

        // Select a random grovcery prefab 
        System.Random random = new System.Random();
        int randomIndex = random.Next(collectedGroceries.Length - 1);
        GameObject prefab = collectedGroceries[randomIndex] as GameObject;

        // Add gravity
        prefab.GetComponent<Rigidbody2D>().gravityScale = gravity;

        // Spawn prefab add random position
        GameObject go = Instantiate(prefab, new Vector3(Random.Range(minX
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

        //Increase item count
        count++;


        IncreaseDifficulty2();


        // Start the spawn again
        StartCoroutine("Spawn");


        
    }
    private void IncreaseDifficulty2()
    {
        Debug.Log(count);
        // Increase difficulty
        if (count == 10)
        {
            spawnTime = 1.5f;
        }
        else if (count == 20)
        {
            Instantiate(flySpawner, new Vector3(0, 0, 0),
            Quaternion.identity);
        }
        else if (count == 30)
        {
            spawnTime = 1;

        }
        else if (count == 40)
        {
            //
        }
    }


}
