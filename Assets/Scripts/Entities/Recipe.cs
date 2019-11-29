using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    public string title;
    public List<Grocery.GroceryType> ingredients;

    public Recipe(string title, List<Grocery.GroceryType> ingredients)
    {
        this.title = title;
        this.ingredients = ingredients;
    }
}
