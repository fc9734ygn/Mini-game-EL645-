using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    public string title;
    public List<Grocery> ingredients;

    public Recipe(string title, List<Grocery> ingredients)
    {
        this.title = title;
        this.ingredients = ingredients;
    }

    public List<Grocery.GroceryType> GetGroceryTypes()
    {
        List<Grocery.GroceryType> types = new List<Grocery.GroceryType> { };
        foreach (Grocery grocery in ingredients)
        {
            types.Add(grocery.groceryType);
        }
        return types;
    }
}
