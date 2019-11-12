using Leap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

    Controller controller;

    private float leapRangeX;
    private float screenRangeX;
    private float leapRangeY;
    private float screenRangeY;
    private Vector3 pos; //Position
    public int score = 0;


    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        InitLeapController();
    }

    private void InitLeapController()
    {
        controller = new Controller();

        leapRangeX = Constants.LEAP_END_COORDINATE_X - Constants.LEAP_START_COORDINATE_X;
        screenRangeX = -Constants.SCREEN_START_COORDINATE_X - Constants.SCREEN_START_COORDINATE_X;
        leapRangeY = Constants.LEAP_END_COORDINATE_Y - Constants.LEAP_START_COORDINATE_Y;
        screenRangeY = -Constants.SCREEN_START_COORDINATE_Y - Constants.SCREEN_START_COORDINATE_Y;
    }

    void Update()
    {
        Frame frame = controller.Frame(); // controller is a Controller object
        if (frame.Hands.Count > 0)
        {
            List<Hand> hands = frame.Hands;
            Hand firstHand = hands[0];

            float newX = MapCoordinate(firstHand.PalmPosition.x, Constants.LEAP_START_COORDINATE_X, leapRangeX, screenRangeX, Constants.SCREEN_START_COORDINATE_X);
            float newY = MapCoordinate(firstHand.PalmPosition.y, Constants.LEAP_START_COORDINATE_Y, leapRangeY, screenRangeY, Constants.SCREEN_START_COORDINATE_Y);

            pos = new Vector3(newX, newY, transform.position.z);
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
