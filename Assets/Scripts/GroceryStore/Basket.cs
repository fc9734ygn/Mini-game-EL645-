using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    private List<Grocery.GroceryType> collectedGroceries = new List<Grocery.GroceryType> { };
    public GameObject recipePanel;
    private Recipe currentRecipe;
    public GameObject healthBarPanel;

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
        return Input.touchCount == 1 && basketBounds.Contains(GetPhoneCursorPosition());
    }


    private Vector2 GetPhoneCursorPosition()
    {
        Vector2 pos = new Vector2(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
        return Camera.main.ScreenToWorldPoint(pos);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        if (otherObject.tag == "Grocery")
        {
            Grocery grocery = otherObject.GetComponent<Grocery>();
            OnGroceryTrigger(grocery);
            otherObject.GetComponent<SpriteRenderer>().enabled = false; 
        }
    }

    private void OnGroceryTrigger(Grocery grocery)
    {
        bool correctGrocery = CheckIfCorrectGrocery(grocery.groceryType);
        if (correctGrocery)
        {
            OnCorrectGroceryTrigger(grocery);
        }
        else
        {
            OnIncorrectGroceryTrigger();
        }
    }

    private bool CheckIfCorrectGrocery(Grocery.GroceryType groceryType)
    {
        if (currentRecipe == null)
        {
            GetCurrentRecipe();
        }

        if (currentRecipe.ingredients.Contains(groceryType))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void GetCurrentRecipe()
    {
        currentRecipe = recipePanel.GetComponent<RecipePanel>().GetCurrentRecipe();
    }

    private void OnCorrectGroceryTrigger(Grocery grocery)
    {
        collectedGroceries.Add(grocery.groceryType);
        healthBarPanel.GetComponent<HealthBar>().Heal(1);
    }

    private void OnIncorrectGroceryTrigger()
    {
        healthBarPanel.GetComponent<HealthBar>().DealDamage(1);
    }
}
