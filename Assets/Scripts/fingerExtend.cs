

using Leap;
using System.Collections.Generic;
using UnityEngine;

public class fingerExtend : MonoBehaviour
{

    Controller controller;


    // Start is called before the first frame update
    void Start()
    {
        controller = new Controller();
    }

    // Update is called once per frame
    void Update()
    {
        Frame frame = controller.Frame(); // controller is a Controller object
        if (frame.Hands.Count > 0)
        {
            List<Hand> hands = frame.Hands;

            Hand firstHand = hands[0];
            if (firstHand.Fingers.Count >= 2)
            {

                if (IsHighFiveTime(firstHand))
                {
                    Debug.Log("High Five!");
                }
                else
                {
                    Debug.Log("Not High Five ;(");
                }
            }
        }
    }
    private bool IsHighFiveTime(Hand hand)
    {
        Finger finger1 = hand.Fingers[0];
        Finger finger2 = hand.Fingers[1];
        Finger finger3 = hand.Fingers[2];
        Finger finger4 = hand.Fingers[3];
        Finger finger5 = hand.Fingers[4];


        bool allExtended = finger1.IsExtended && finger2.IsExtended && finger3.IsExtended && finger4.IsExtended && finger5.IsExtended;
        bool allPointingUp = finger1.Direction.y > 0 && finger2.Direction.y > 0 && finger3.Direction.y >0 && finger4.Direction.y > 0 && finger5.Direction.y > 0;

        return allExtended && allPointingUp;
    }
 
}

