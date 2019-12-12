using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Constants.TOOLTYPE currentTool;
    TrailRenderer myTrailRenderer;
    // Score counter
    public GameObject scoreBoard;
    // Score
    public static int scoreCount;
    // AudioSource component
    private AudioSource audioSource;
    // Audio Clips
    public AudioClip knifeAudio;
    public AudioClip handAudio;
    public AudioClip mortarAudio;
    public AudioClip graterAudio;
    public AudioClip errorAudio;
    public AudioClip buttonAudio;
    private AudioClip currentAudio;
     void Start()
    {
        // Initiate score
        scoreCount = 0;
        // Get Audio Source
        audioSource = GetComponent<AudioSource>();
        // Initiate current audio clip
        currentAudio = knifeAudio;
        // Get Trail Renderer
        myTrailRenderer = GetComponent<TrailRenderer>();
        // Get screen orientation
        Screen.orientation = ScreenOrientation.Landscape;
        // Prevent phone screen from "sleeping"
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        // change trail renderer colour
        myTrailRenderer.startColor = Constants.KNIFECOLOR;
        myTrailRenderer.endColor = Constants.KNIFECOLOR;
        // change sound effect
        currentAudio = knifeAudio;
        currentTool = Constants.TOOLTYPE.Knife;
    }
    void Update()
    {
        TrackCursor();
    }
    private void TrackCursor()
    {
        // If finger on screen
        if (Input.touchCount == 1)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                transform.position = GetPhoneCursorPosition();
            }
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            gameObject.GetComponent<TrailRenderer>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponent<TrailRenderer>().enabled = false;
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
                scoreCount += 15;
            }
            else
            {
                // Loose points
                scoreCount += 5;

            }
            audioSource.clip = currentAudio;
            audioSource.Play();
            Destroy(other.gameObject);
            scoreBoard.gameObject.GetComponent<ScoreCounter>().SetScore(scoreCount);
        }
        else if (other.gameObject.CompareTag("Fly"))
        {
            scoreCount  -= 10;
            scoreBoard.gameObject.GetComponent<ScoreCounter>().SetScore(scoreCount);
            audioSource.clip = errorAudio;
            audioSource.Play();
        }
    }

        // When one of the tool button is pressed
        public void ToolButtonPressed(int tool)
    {
        // Change the current tool and call change state
        currentTool = (Constants.TOOLTYPE)tool;


        UpdateState();
    }




    // Changes the trail renderer colour and sound effect on selection
    private void UpdateState()
    { 
        switch(currentTool)
        {
            case Constants.TOOLTYPE.Knife:
                // change trail renderer colour
                myTrailRenderer.startColor = Constants.KNIFECOLOR;
                myTrailRenderer.endColor = Constants.KNIFECOLOR;
                // change sound effect
                currentAudio = knifeAudio;
                break;
            case Constants.TOOLTYPE.Mortar:
                // change trail renderer colour
                myTrailRenderer.startColor = Constants.MORTARCOLOR;
                myTrailRenderer.endColor = Constants.MORTARCOLOR;
                // change sound effect
                currentAudio = mortarAudio;
                break;
            case Constants.TOOLTYPE.Grater:
                // change trail renderer colour
                myTrailRenderer.startColor = Constants.GRATERCOLOR;
                myTrailRenderer.endColor = Constants.GRATERCOLOR;
                // change sound effect
                currentAudio = graterAudio;
                break;
            case Constants.TOOLTYPE.Hand:
                // change trail renderer colour
                myTrailRenderer.startColor = Constants.HANDCOLOR;
                myTrailRenderer.endColor = Constants.HANDCOLOR;
                // change sound effect
                currentAudio = handAudio;
                break;
        }
        audioSource.clip = buttonAudio;
        audioSource.Play();

    }
}
