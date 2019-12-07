using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RecipeGenerator
{
    public static Recipe GetRandomRecipe()
    {
        Recipe recipe;
        var random = Random.Range(0, 3);
        switch (random)
        {
            case 0:
                recipe = new Recipe("Spaghetti Bolognese",
                    new List<Grocery> {
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon)
                    });
                break;
            case 1:
                recipe = new Recipe("Spaghetti Bolognese",
                    new List<Grocery> {
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon)
                    });
                break;
            case 2:
                recipe = new Recipe("Spaghetti Bolognese",
                    new List<Grocery> {
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon)
                    });
                break;
            case 3:
                recipe = new Recipe("Spaghetti Bolognese",
                    new List<Grocery> {
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon)
                    });
                break;
            default:
                recipe = new Recipe("Spaghetti Bolognese",
                    new List<Grocery> {
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Bacon)
                    });
                break;
        }
        return recipe;
    }
}
