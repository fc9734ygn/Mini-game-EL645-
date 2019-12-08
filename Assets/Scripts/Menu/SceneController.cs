using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadGroceryScene()
    {
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync("GroceryStore"));
    }

    public void LoadKitchenScene()
    {
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync("Kitchen"));
    }

    public void LoadTutorialScene()
    {
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync("Tutorial"));
    }

    public void LoadHighScoresScene()
    {
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync("Highscores"));
    }

    public void LoadCreditsScene()
    {
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync("Credits"));
    }

    public void LoadMenu()
    {
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync("Menu"));
    }
}
