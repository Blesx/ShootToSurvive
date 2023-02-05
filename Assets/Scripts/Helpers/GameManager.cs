using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainMenu"));
        Debug.Log("Active scene: " + SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        StartCoroutine(LoadGameScene());
    }

    public void RestartGame()
    {
        DestroyStatObserver();
        StartCoroutine(LoadGameScene());
    }

    IEnumerator LoadGameScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MyGame", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        while (!asyncLoad.isDone) 
        {
            yield return null;
        }   

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MyGame"));
        Debug.Log("Active scene: " + SceneManager.GetActiveScene().name);

    }

    public void EndGame()
    {
        StartCoroutine(LoadScoreScene());
    }

    IEnumerator LoadScoreScene() 
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("ScoreScreen", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        while (!asyncLoad.isDone) 
        { 
            yield return null;
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("ScoreScreen"));
        Debug.Log("Active scene: " + SceneManager.GetActiveScene().name);
    
    }

    public void ReturnToStart()
    {
        DestroyStatObserver();
        StartCoroutine(LoadMainMenu());
    }

    IEnumerator LoadMainMenu()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainMenu"));
        Debug.Log("Active scene: " + SceneManager.GetActiveScene().name);
    }

    public void DestroyStatObserver()
    {
        GameObject statObserver = GameObject.Find("Stat Observer");
        Destroy(statObserver);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

}
