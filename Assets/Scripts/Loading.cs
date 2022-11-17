using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Loading : MonoBehaviour
{
    // canvas components to enable / disable
    [SerializeField] private Canvas menu;
    Canvas loading;

    [SerializeField] Slider progressBar;
    [SerializeField] TextMeshProUGUI loadingText;
    [SerializeField] string sceneName = "SampleScene";
    [SerializeField] string credits = "SampleScene";

    private void Start()
    {
        loading = GetComponent<Canvas>();
        
        // main menu enabled and loading disabled
        loading.enabled = false;
        menu.enabled = true;
    }

    public void StartGame()
    {
        StartCoroutine(LoadYourAsyncScene(sceneName));
        loading.enabled = true;
        menu.enabled = false;
    }

    public void Credits()
    {
        SceneManager.LoadScene(credits);
        menu.enabled = false;
    }

    public void QuitGame()
    {
        // Application.Quit();
    }

    IEnumerator LoadYourAsyncScene(string s)
    {
        // The Application loads the Scene in the background as the current Scene runs.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(s);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            //MuncDuster grepper result
            Debug.Log("Operation progress");

            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);

            loadingText.text = Mathf.RoundToInt(progress * 100) + "%";
            progressBar.value = progress;

            yield return new WaitForEndOfFrame();

        }
    }
}