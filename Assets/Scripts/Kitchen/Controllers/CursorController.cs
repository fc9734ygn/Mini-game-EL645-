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
        TrackCursor();
    }

    private void TrackCursor()
    {

        if (Input.touchCount == 1)
        {

            if (Application.platform == RuntimePlatform.Android)
            {
                transform.position = GetPhoneCursorPosition();
            }
            GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }

    private Vector3 GetPhoneCursorPosition()
    {
        //Find screen touch position, by
        //transforming position from screen space into game world space.
        pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 1));
        return new Vector3(pos.x, pos.y, 3);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

    }
}
