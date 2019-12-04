using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Constants.TOOLTYPE currentTool = Constants.TOOLTYPE.Knife;
    TrailRenderer myTrailRenderer;



    void Start()
    {
        myTrailRenderer = GetComponent<TrailRenderer>();
        Screen.orientation = ScreenOrientation.Landscape;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        UpdateState();
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

            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    private Vector3 GetPhoneCursorPosition()
    {
        Vector3 pos;
        pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 1));
        return new Vector3(pos.x, pos.y, 3);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Grocery"))
        {
            if(other.gameObject.GetComponent<Grocery>().tool == currentTool)
            {
                // Get Points
                Destroy(other.gameObject);
            }
            else
            {
                // Loose points
            }
        }
        else if (other.gameObject.CompareTag("Fly"))
        {
            //Destroy(other.gameObject);
        }
    }

    // When one of the tool button is pressed
    public void ToolButtonPressed(int tool)
    {
        // Change the current tool and call change state
        currentTool = (Constants.TOOLTYPE)tool;
        Debug.Log(tool);

        UpdateState();
    }




    // Changes the player's sprite and collision sound
    private void UpdateState()
    { 
        switch(currentTool)
        {

            case Constants.TOOLTYPE.Knife:
                // change sound effect
                myTrailRenderer.startColor = Constants.KNIFECOLOR;
                myTrailRenderer.endColor = Constants.KNIFECOLOR;

                break;
            case Constants.TOOLTYPE.Mortar:
                // change sound effect
                myTrailRenderer.startColor = Constants.MORTARCOLOR;
                myTrailRenderer.endColor = Constants.MORTARCOLOR;

                break;
            case Constants.TOOLTYPE.Grater:
                // change sound effect
                myTrailRenderer.startColor = Constants.GRATERCOLOR;
                myTrailRenderer.endColor = Constants.GRATERCOLOR;

                break;
            case Constants.TOOLTYPE.Hand:
                // change sound effect
                myTrailRenderer.startColor = Constants.HANDCOLOR;
                myTrailRenderer.endColor = Constants.HANDCOLOR;
                break;

        }

    }


}
