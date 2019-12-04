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
        if (transform.position.x > Constants.MAXSCREENWIDTH || transform.position.x < -Constants.MAXSCREENWIDTH || transform.position.y > Constants.MAXSCREENHEIGHT || transform.position.y < -Constants.MAXSCREENHEIGHT)
        {
            transform.Rotate(new Vector3(0, 0, 180));
        }
        else if (transform.position.x < Constants.MAXSCREENWIDTH + minDist && transform.position.x > -Constants.MAXSCREENWIDTH - minDist && transform.position.y < Constants.MAXSCREENHEIGHT + minDist && transform.position.y > -Constants.MAXSCREENHEIGHT - minDist)
        {
            transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));

        }

        transform.position += transform.up * movementSpeed * Time.deltaTime;


    }
}