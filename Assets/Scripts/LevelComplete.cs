using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelComplete : MonoBehaviour
{

    static public string previousSceneID;
    static public string previousSceneName;
    static public double completionTime;

    public TextMeshProUGUI completionText;
    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        completionText.text = previousSceneName + " Complete!";
        if (completionTime != 0.0)
        {
            timeText.text = "Completion time: " + completionTime.ToString() + " seconds";
        }
        else
        {
            timeText.text = "";
        }
    }

    public void LoadPreviousScene()
    {
        Debug.Log("Previous scene: " + previousSceneID);
        Debug.Log(previousSceneID == null);

        if (previousSceneID != null)
        {
            Debug.Log("Resetting to " + previousSceneID);
            LoadNextScene(previousSceneID);
            // Reset(previousSceneID);
            // SceneManager.LoadScene(previousSceneID);
        }
        
    }

    public void LoadLobby()
    {
        Debug.Log("Resetting to Lobby");
        LoadNextScene("Lobby");
        // Reset("Lobby");
        // SceneManager.LoadScene("Lobby");
    }

    private void LoadNextScene(string scene)
    {
        Debug.Log("Loading scene: " + scene);
        previousSceneID = previousSceneName = null;
        completionTime = 0.0;
        SceneManager.LoadScene(scene);
    }
}
