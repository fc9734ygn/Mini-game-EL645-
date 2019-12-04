using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadGroceryScene()
    {
        SceneManager.LoadScene("GroceryStore", LoadSceneMode.Single);
    }

    public void LoadKitchenScene()
    {
        SceneManager.LoadScene("Kitchen", LoadSceneMode.Single);
    }

    public void LoadTutorialScene()
    {
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }

    public void LoadHighScoresScene()
    {
        SceneManager.LoadScene("Highscores", LoadSceneMode.Single);
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
