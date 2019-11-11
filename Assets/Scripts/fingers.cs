using Leap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fingers : MonoBehaviour
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
                Finger finger1 = firstHand.Fingers[0];
                Finger finger2 = firstHand.Fingers[1];
                transform.localScale = Vector3.one * GetDistance(finger1,finger2) / 10;
            }
        }
    }

    private float GetDistance(Finger f1, Finger f2)
    {

        float distance;
        Vector f1tip = f1.TipPosition;
        Vector f2tip = f2.TipPosition;


        distance = Mathf.Sqrt(((f1tip.x - f2tip.x)*(f1tip.x - f2tip.x)) + ((f1tip.y - f2tip.y)*(f1tip.y - f2tip.y)) + ((f1tip.z - f2tip.z) * (f1tip.z - f2tip.z)));
        return distance;
    }
}

