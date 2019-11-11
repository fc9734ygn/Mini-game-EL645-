using Leap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour
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


    void Start()
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

            float newX = MapCoordinate(firstHand.PalmPosition.x,leapStartX, leapRangeX, appRangeX, appStartX);
            float newY = MapCoordinate(firstHand.PalmPosition.y, leapStartY, leapRangeY, appRangeY, appStartY);

            this.gameObject.transform.position = new Vector3(newX, newY, transform.position.z);
        }
    }

    float MapCoordinate(float leap, float leapStart, float leapRange, float appRange, float appStart)
    {
        float mapped;
        mapped = (leap - leapStart) * (appRange/leapRange) + appStart;
        return mapped;
    }
  
}
