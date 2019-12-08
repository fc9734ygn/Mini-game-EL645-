using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public static LoadingScreen Instance;
    public GameObject loadingText;
    public GameObject groceries;
    public float groceryRotationSpeed;
    public float minLoadingTimeInSeconds;

    // The reference to the current loading operation running in the background:
    private AsyncOperation currentLoadingOperation;

    // A flag to tell whether a scene is being loaded or not:
    private bool isLoading;

    // The elapsed time since the new scene started loading:
    private float timeElapsed;

    private void Awake()
    {
        // Singleton logic:
        if (Instance == null)
        {
            Instance = this;

            // Don't destroy the loading screen while switching scenes:
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        Hide();
    }
   
    private void Update()
    {
        // If the loading is complete, hide the loading screen:
        if (currentLoadingOperation.isDone)
        {
            Hide();
        }
        else
        {
            rotateGrocery(groceries);
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= minLoadingTimeInSeconds)
            {
                // The loading screen has been showing for the minimum time required.
                // Allow the loading operation to formally finish:
                currentLoadingOperation.allowSceneActivation = true;
            }
        }
    }

    // Call this to show the loading screen.
    // We can determine the loading's progress when needed from the AsyncOperation param:
    public void Show(AsyncOperation loadingOperation)
    {
        // Enable the loading screen:
        gameObject.SetActive(true);

        // Store the reference:
        currentLoadingOperation = loadingOperation;

        // Stop the loading operation from finishing, even if it technically did:
        currentLoadingOperation.allowSceneActivation = false;

        // Reset the time elapsed:
        timeElapsed = 0f;

        isLoading = true;

        // Start loading text animation
        StartCoroutine(LoadingTextAnimation());
        groceries.SetActive(true);


    }

    // Call this to hide it:
    public void Hide()
    {
        // Disable the loading screen:
        gameObject.SetActive(false);
        currentLoadingOperation = null;
        isLoading = false;

        Canvas canvas = GetComponent<Canvas>();
        canvas.worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    IEnumerator LoadingTextAnimation()
    {
        TextMeshProUGUI text = loadingText.GetComponent<TextMeshProUGUI>();

        text.SetText("Loading.");
        yield return new WaitForSeconds(0.25f);
        text.SetText("Loading..");
        yield return new WaitForSeconds(0.25f);
        text.SetText("Loading...");
        yield return new WaitForSeconds(0.25f);

        StartCoroutine(LoadingTextAnimation());
    }

    private void rotateGrocery(GameObject grocery)
    {
        grocery.transform.Rotate(new Vector3(0, 0, -groceryRotationSpeed * Time.deltaTime));
    }
}
