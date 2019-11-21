using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grocery : MonoBehaviour
{
    public Grocery.Tool tool;
    public GroceryType groceryType;

    public enum Tool
    {
        Knife,
        Mortar,
        Grater,
        Hand
    }

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
    }

}


