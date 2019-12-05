using UnityEngine;
using System.Collections;

public class FlyController : MonoBehaviour
{

    public int rotationSpeed = 150;
    public float movementSpeed = 6;
    private int rotationTime = 1;
    private readonly int minDist = 2;

    void Start()
    {
        Invoke("ChangeRotation", rotationTime);
    }

    void ChangeRotation()
    {

        Debug.Log(rotationTime);
        if (Random.value > 0.5f)
        {
            rotationSpeed = -rotationSpeed;
        }
        Invoke("ChangeRotation", rotationTime);

    }


    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
        transform.position += transform.up * movementSpeed * Time.deltaTime;

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Border"))
        { 
        transform.Rotate(new Vector3(0, 0, 180));
        transform.position += 2 * transform.up * movementSpeed * Time.deltaTime;
        }
    }
}