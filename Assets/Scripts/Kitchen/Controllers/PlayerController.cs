using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Tool currentTool = Tool.Knife;

    // Declare Sprites
    public Sprite knifeSprite;
    public Sprite mortarSprite;
    public Sprite graterSprite;
    public Sprite handSprite;

    // Declare sprite renderer
    private SpriteRenderer spriteRenderer;


    public enum Tool
    {
        Knife,
        Mortar,
        Grater,
        Hand
    }

    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        ChangeState();
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
            gameObject.SetActive(false);
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

    }

    // When one of the tool button is pressed
    public void ToolButtonPressed(Tool tool)
    {
        // Change the current tool and call change state
        currentTool = tool;
        ChangeState();
    }

    // Changes the player's sprite and collision sound
    private void ChangeState()
    { 
        switch(currentTool)
        {

            case Tool.Knife:
                spriteRenderer.sprite = knifeSprite;
                // change sound effect
                break;
            case Tool.Mortar:
                spriteRenderer.sprite = mortarSprite;
                // change sound effect
                break;
            case Tool.Grater:
                spriteRenderer.sprite = graterSprite;
                // change sound effect

                break;
            case Tool.Hand:
                spriteRenderer.sprite = handSprite;
                // change sound effect

               break;

        }


    }

}
