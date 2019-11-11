using Leap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Controller controller;

    const float appStartX = -17f;
    const float appEndX = -appStartX;
    const float leapStartX = -200f;
    const float leapEndX = -leapStartX;

    const float appStartY = -6f;
    const float appEndY = 8f;
    const float leapStartY = 45f;
    const float leapEndY = 500f;

    private float leapRangeX;
    private float appRangeX;
    private float leapRangeY;
    private float appRangeY;


    private Vector3 pos; //Position
    public int score = 0;


    void Start()
    {
        //Set screen orientation to landscape
        Screen.orientation = ScreenOrientation.Landscape;
        //Set sleep timeout to never fgfgf
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        InitLeapController();
    }

    private void InitLeapController()
    {
        //create a new leap controller
        controller = new Controller();

        leapRangeX = leapEndX - leapStartX;
        appRangeX = -appStartX - appStartX;
        leapRangeY = leapEndY - leapStartY;
        appRangeY = -appStartY - appStartY;
    }

    void Update()
    {
        Frame frame = controller.Frame(); // controller is a Controller object
        if (frame.Hands.Count > 0)
        {
            List<Hand> hands = frame.Hands;
            Hand firstHand = hands[0];

            float newX = MapCoordinate(firstHand.PalmPosition.x, leapStartX, leapRangeX, appRangeX, appStartX);
            float newY = MapCoordinate(firstHand.PalmPosition.y, leapStartY, leapRangeY, appRangeY, appStartY);

            //Find mouse position
            pos = new Vector3(newX, newY, transform.position.z);
            //Set position
            transform.position = new Vector3(pos.x, pos.y, 3);

        }

    }

    float MapCoordinate(float leap, float leapStart, float leapRange, float appRange, float appStart)
    {
        float mapped;
        mapped = (leap - leapStart) * (appRange / leapRange) + appStart;
        return mapped;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fruit")
        {
            other.gameObject.transform.GetComponent<Fruit2D>().Hit();
            score++;
            Debug.Log(score);

        }
        if (other.tag == "Bomb")
        {
            other.gameObject.transform.GetComponent<Bomb2D>().Hit();
            score = score - 2;
            Debug.Log(score);

        }
    }
}
