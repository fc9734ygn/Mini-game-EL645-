using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_items : MonoBehaviour
{
    public float spawnTime= 1;

    public float upForce = 750; //Up force
    public float leftRightForce = 200; //Left and right force
    public float gravity = 1;
    public float maxX = -10; //Max x spawn position
    public float minX = 10; //Min x spawn position

    private Object[] collectedGroceries;

    void Start()
    {
        collectedGroceries = Resources.LoadAll("Prefab/Groceries", typeof(GameObject));
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        //Wait spawnTime
        yield return new WaitForSeconds(spawnTime);
        //Spawn prefab is apple
        System.Random random = new System.Random();
        int randomIndex = random.Next(collectedGroceries.Length - 1);
        GameObject prefab = collectedGroceries[randomIndex] as GameObject;
        prefab.GetComponent<Rigidbody2D>().gravityScale = gravity;

        //Spawn prefab add randomc position
        GameObject go = Instantiate(prefab, new Vector3(Random.Range(minX
        , maxX + 1), transform.position.y, 0f), Quaternion.Euler(0, 0, Random.Range(-
        90F, 90F))) as GameObject;
        //If x position is over 0 go left
        if (go.transform.position.x > 0)
        {
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(-
            leftRightForce, upForce));
        }
        //Else go right
        else
        {
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(leftRightForce, upForce));
        }
        //Start the spawn again
        StartCoroutine("Spawn");
    }
}
