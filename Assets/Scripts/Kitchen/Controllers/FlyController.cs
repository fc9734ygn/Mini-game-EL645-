using UnityEngine;
using System.Collections;

public class FlyController : MonoBehaviour
{

    public int rotationSpeed = 180;
    public float movementSpeed = 4.5f;
    private float rotationTime = 1.0f;
    private readonly float minDist = 1.2f;

    void Start()
    {
        Invoke("ChangeRotation", rotationTime);
    }

    void ChangeRotation()
    {
        rotationTime = Random.Range(0.6f, 1.2f);
        Debug.Log(rotationTime);
        if (Random.value > 0.5f)
        {
            rotationSpeed = -rotationSpeed;
        }
        Invoke("ChangeRotation", rotationTime);

    }


    void Update()
    {
        if (transform.position.x > Constants.MAXSCREENWIDTH || transform.position.x < -Constants.MAXSCREENWIDTH || transform.position.y > Constants.MAXSCREENHEIGHT || transform.position.y < -Constants.MAXSCREENHEIGHT)
        {
            transform.Rotate(new Vector3(0, 0, 180));
            transform.position += transform.up * movementSpeed * Time.deltaTime;

        }
        else if (transform.position.x > Constants.MAXSCREENWIDTH + minDist || transform.position.x < -Constants.MAXSCREENWIDTH - minDist || transform.position.y > Constants.MAXSCREENHEIGHT + minDist || transform.position.y < -Constants.MAXSCREENHEIGHT - minDist)
        {
            transform.position += transform.up * movementSpeed * Time.deltaTime;
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
            transform.position += transform.up * movementSpeed * Time.deltaTime;

        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        transform.Rotate(new Vector3(0, 0, 180));
    }
}