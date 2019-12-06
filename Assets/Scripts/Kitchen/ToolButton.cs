using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ToolButton : MonoBehaviour
{
    private Toggle button;
    public Sprite imageOn;
    public Sprite imageOff;



    void Start()
    {
        
        button = this.gameObject.GetComponent<Toggle>();
        button.onValueChanged.AddListener((bool On) => Switch(On));

    }
    void Switch(bool isOn)
    {
        if (isOn)
        {
            button.GetComponent<Image>().sprite = imageOn;
        }
        else
        {
           button.GetComponent<Image>().sprite = imageOff;

        }
    }
}
