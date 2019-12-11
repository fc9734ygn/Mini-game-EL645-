using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RecipeGenerator
{
    public static Recipe GetRandomRecipe()
    {
        Recipe recipe;
        var random = Random.Range(0, 4);

        switch (random)
        {
            case 0:
                recipe = new Recipe(Constants.RECIPE_0,
                    new List<Grocery> {
                        new Grocery(Constants.TOOLTYPE.Knife, Grocery.GroceryType.Onion),
                        new Grocery(Constants.TOOLTYPE.Knife, Grocery.GroceryType.Tomato),
                        new Grocery(Constants.TOOLTYPE.Mortar, Grocery.GroceryType.Basil),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Cheese),
                        new Grocery(Constants.TOOLTYPE.Hand, Grocery.GroceryType.Oil),
                        new Grocery(Constants.TOOLTYPE.Hand, Grocery.GroceryType.Pasta)
                    });
                break;
            case 1:
                recipe = new Recipe(Constants.RECIPE_1,
                    new List<Grocery> {
                        new Grocery(Constants.TOOLTYPE.Knife, Grocery.GroceryType.Beef),
                        new Grocery(Constants.TOOLTYPE.Knife, Grocery.GroceryType.Tomato),
                        new Grocery(Constants.TOOLTYPE.Mortar, Grocery.GroceryType.Basil),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Carrots),
                        new Grocery(Constants.TOOLTYPE.Hand, Grocery.GroceryType.Oil),
                        new Grocery(Constants.TOOLTYPE.Hand, Grocery.GroceryType.Pasta)
                    });
                break;
            case 2:
                recipe = new Recipe(Constants.RECIPE_2,
                    new List<Grocery> {
                        new Grocery(Constants.TOOLTYPE.Knife, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Knife, Grocery.GroceryType.Butter),
                        new Grocery(Constants.TOOLTYPE.Mortar, Grocery.GroceryType.Salt),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Cheese),
                        new Grocery(Constants.TOOLTYPE.Hand, Grocery.GroceryType.Eggs),
                        new Grocery(Constants.TOOLTYPE.Hand, Grocery.GroceryType.Pasta)

                    });
                break;
            case 3:
                recipe = new Recipe(Constants.RECIPE_3,
                    new List<Grocery> {
                        new Grocery(Constants.TOOLTYPE.Knife, Grocery.GroceryType.Garlic),
                        new Grocery(Constants.TOOLTYPE.Mortar, Grocery.GroceryType.Pepper),
                        new Grocery(Constants.TOOLTYPE.Mortar, Grocery.GroceryType.Parsley),
                        new Grocery(Constants.TOOLTYPE.Grater, Grocery.GroceryType.Cheese),
                        new Grocery(Constants.TOOLTYPE.Hand, Grocery.GroceryType.Oil),
                        new Grocery(Constants.TOOLTYPE.Hand, Grocery.GroceryType.Pasta)

                    });
                break;
            default:
                recipe = new Recipe("Spaghetti le Bacon",
                    new List<Grocery> {
                        new Grocery(Constants.TOOLTYPE.Knife, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Knife, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Knife, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Knife, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Knife, Grocery.GroceryType.Bacon),
                        new Grocery(Constants.TOOLTYPE.Hand, Grocery.GroceryType.Pasta)
                    });
                break;
        }
        return recipe;
    }
}
