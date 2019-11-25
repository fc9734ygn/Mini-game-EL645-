using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{

    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

    }

    void Update()
    {
       
        if (CheckIfSelected())
        {
            MoveBasket();
        }
    }

    private void MoveBasket()
    {
        transform.position = new Vector3(GetPhoneCursorPosition().x, transform.position.y);
    }

    private bool CheckIfSelected()
    {
        Bounds basketBounds = GetComponent<SpriteRenderer>().bounds;
      
      //  Debug.Log("bounds  " + basketBounds.ToString() + "cursor pos   " + cursorPos.ToString() + "is in bounds   " + basketBounds.Contains(GetPhoneCursorPosition()));
        return Input.touchCount == 1 && basketBounds.Contains(GetPhoneCursorPosition());
    }


    private Vector2 GetPhoneCursorPosition()
    {
       // Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        Vector2 pos = new Vector2(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
        return Camera.main.ScreenToWorldPoint(pos);
    }


    void OnTriggerEnter2D(Collider2D other)
    {

    }
}
