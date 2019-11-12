using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splat2D : MonoBehaviour
{
    private Color color; //Color
    public float destroySpeed = 0.2f; //Destroy Speed
    void Start()
    {
        //Set the color
        color = GetComponent<SpriteRenderer>().color;
    }
    void Update()
    {
        //Set the mesh material color
        GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, color.a -= destroySpeed * Time.deltaTime);
        //If color a is 0
        if (color.a <= 0)
        {
            //Destroy
            Destroy(gameObject);
        }
    }
}
