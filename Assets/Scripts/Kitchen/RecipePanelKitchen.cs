using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipePanelKitchen : MonoBehaviour
{
    public GameObject recipeTitleUI;
    public GameObject gridItemPrefab;
    public GridLayoutGroup gridLayout;
    private Recipe currentRecipe;

    //List because unity editor don't support dictionaries
    [SerializeField] public List<GrocerySpritesEntry> grocerySprites;
    [SerializeField] public List<ToolSpritesEntry> toolSprites;

    //used to map grocery types and tool types to corresponding sprites
    private Dictionary<Grocery.GroceryType, Sprite> grocerySpriteLookup;
    private Dictionary<Constants.TOOLTYPE, Sprite> toolSpriteLookup;

    [Serializable]
    public class GrocerySpritesEntry
    {
        public Grocery.GroceryType type;
        public Sprite sprite;
    }

    [Serializable]
    public class ToolSpritesEntry
    {
        public Constants.TOOLTYPE type;
        public Sprite sprite;
    }

    private void Start()
    {
        //TODO: remove dummy data
        // SetCurrentRecipe() should be called from outside of the class at the start of the scene
        var recipe = new Recipe("Spaghetti aglio e olio",
            new List<Grocery> {
            new Grocery(Constants.TOOLTYPE.Knife,Grocery.GroceryType.Bacon),
            new Grocery(Constants.TOOLTYPE.Knife,Grocery.GroceryType.Tomato),
            new Grocery(Constants.TOOLTYPE.Mortar,Grocery.GroceryType.Parsley),
            new Grocery(Constants.TOOLTYPE.Grater,Grocery.GroceryType.Cheese),
            new Grocery(Constants.TOOLTYPE.Hand,Grocery.GroceryType.Oil)
            }
        );

        SetCurrentRecipe(recipe);
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
        foreach (Grocery grocery in currentRecipe.ingredients)
        {
            SpawnGridItem(grocery);
        }
    }

    private void SpawnGridItem(Grocery grocery)
    {
        GameObject newGridItem = Instantiate(gridItemPrefab);

        GameObject groceryIcon = newGridItem.transform.Find("GroceryImage").gameObject;
        GameObject toolIcon = newGridItem.transform.Find("ToolImage").gameObject;

        Debug.Log(groceryIcon);
        Debug.Log(toolIcon);


        groceryIcon.GetComponent<Image>().sprite = grocerySpriteLookup[grocery.groceryType];
        toolIcon.GetComponent<Image>().sprite = toolSpriteLookup[grocery.tool];

        newGridItem.transform.SetParent(gridLayout.transform, false);
        newGridItem.transform.localScale = new Vector3(1, 1, 1);
        newGridItem.transform.localPosition = Vector3.zero;
    }

    private void AssignSprites()
    {
        grocerySpriteLookup = new Dictionary<Grocery.GroceryType, Sprite>();
        toolSpriteLookup = new Dictionary<Constants.TOOLTYPE, Sprite>();

        foreach (GrocerySpritesEntry entry in grocerySprites)
        {
            grocerySpriteLookup.Add(entry.type, entry.sprite);
        }

        foreach (ToolSpritesEntry entry in toolSprites)
        {
            toolSpriteLookup.Add(entry.type, entry.sprite);
        }
    }
}
