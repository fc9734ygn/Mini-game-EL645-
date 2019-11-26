using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grocery : MonoBehaviour
{
    public Constants.TOOLTYPE tool;
    public GroceryType groceryType;


    public enum GroceryType
    {
        Onion,
        Parsley,
        Tomato,
        Beef,
        Salt,
        Pepper,
        Basil,
        Cheese,
        Carrots,
        Garlic,
        Oil,
        Pasta,
        Bacon,
        Other //random items
    }

}


