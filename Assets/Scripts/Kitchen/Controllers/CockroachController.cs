using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockroachController : MonoBehaviour
{
    public int rotationSpeed = 100;
    public float movementSpeed = 2;
    public float changeTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangeRotation", changeTime);
    }
    void ChangeRotation()
    {

        if (Random.value > 0.5f)
        {
            rotationSpeed = -rotationSpeed;
        }
        Invoke("ChangeRotation", changeTime);

    }

    // Update is called once per frame
    void Update()
    {
        if (Random.value < 0.1f)
        {
            if (FindClosestGrocery())
            {
                Vector2 direction = FindClosestGrocery().GetComponent<Transform>().position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            }

        }
        else 
        {
            transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
        }
        transform.position += 2 * transform.up * movementSpeed * Time.deltaTime;

    }





    GameObject FindClosestGrocery()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Grocery");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
     void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Border"))
        {
            transform.Rotate(new Vector3(0, 0, 180));
            transform.position += 2 * transform.up * movementSpeed * Time.deltaTime;
        }
       

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Grocery"))
        {

            Destroy(other.gameObject);
        }

    }
}