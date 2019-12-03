using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Constants.TOOLTYPE currentTool = Constants.TOOLTYPE.Knife;
    TrailRenderer myTrailRenderer;

    // Declare trail colours
    private Color knifeColor = new Color(0.796f, 0.82f, 0.859f);
    private Color mortarColor = new Color(0.118f, 0.396f, 0.627f);
    private Color graterColor = new Color(0.988f, 0.318f, 0.369f);
    private Color handColor = new Color(0.996f, 0.843f, 0.69f);


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

            }
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
                Debug.Log("knife");
                myTrailRenderer.material.SetColor("_Color", knifeColor);
                break;
            case Constants.TOOLTYPE.Mortar:
                // change sound effect
                Debug.Log("mortar");
                myTrailRenderer.material.SetColor("_Color", mortarColor);
                break;
            case Constants.TOOLTYPE.Grater:
                // change sound effect
                Debug.Log("grater");
                myTrailRenderer.material.SetColor("_Color", graterColor);



                break;
            case Constants.TOOLTYPE.Hand:
                // change sound effect
                Debug.Log("hand");
                myTrailRenderer.material.SetColor("_Color", handColor);


                break;

        }

    }


}
