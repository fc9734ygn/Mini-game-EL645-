using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipePanel : MonoBehaviour
{
    public GameObject recipeTitleUI;
    public GameObject gridItemPrefab;
    public GridLayoutGroup gridLayout;
    private Recipe currentRecipe;

    //List because unity editor don't support dictionaries
    [SerializeField] public List<GrocerySpritesEntry> grocerySprites;
    //used to map grocery types to corresponding sprites
    private Dictionary<Grocery.GroceryType, Sprite> grocerySpriteLookup;

    [Serializable]
    public class GrocerySpritesEntry
    {
        public Grocery.GroceryType type;
        public Sprite sprite;
    }

    private void Start()
    {
        //TODO: remove dummy data
        // SetCurrentRecipe() should be called from outside of the class at the start of the scene
        SetCurrentRecipe(new Recipe("Spaghetti aglio e olio", new List<Grocery.GroceryType> { Grocery.GroceryType.Bacon, Grocery.GroceryType.Cheese, Grocery.GroceryType.Pepper, Grocery.GroceryType.Tomato, Grocery.GroceryType.Beef, Grocery.GroceryType.Garlic }));
    }

    private void Awake()
    {
        AssignSprites();
    }

    public void SetCurrentRecipe(Recipe newRecipe)
    {
        currentRecipe = newRecipe;
        UpdateHUD();
    }

    public Recipe GetCurrentRecipe()
    {
        return currentRecipe;
    }

    private void UpdateHUD()
    {
        recipeTitleUI.GetComponent<TextMeshProUGUI>().SetText(currentRecipe.title);
        InitGrid();
    }
    
    private void InitGrid()
    {
        foreach(Grocery.GroceryType groceryType in currentRecipe.ingredients)
        {
            SpawnGridItem(groceryType);
        }
    }

    private void SpawnGridItem(Grocery.GroceryType groceryType)
    {
        GameObject newGridItem = Instantiate(gridItemPrefab);

        newGridItem.GetComponent<Image>().sprite = grocerySpriteLookup[groceryType];
        newGridItem.transform.SetParent(gridLayout.transform, false);
        newGridItem.transform.localScale = new Vector3(1, 1, 1);
        newGridItem.transform.localPosition = Vector3.zero;
        newGridItem.GetComponentInChildren<TextMeshProUGUI>().SetText(groceryType.ToString());
    }

    private void AssignSprites()
    {
        grocerySpriteLookup = new Dictionary<Grocery.GroceryType, Sprite>();

        foreach (GrocerySpritesEntry entry in grocerySprites)
        {
            grocerySpriteLookup.Add(entry.type, entry.sprite);
        }
    }
}
