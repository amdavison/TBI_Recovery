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
        if (previousSceneID != null)
        {
            Reset();
            SceneManager.LoadScene(previousSceneID);
        }
        
    }

    public void LoadLobby()
    {
        Reset();
        // SceneManager.LoadScene("Lobby");
        Application.Quit();
    }

    void Reset()
    {
        previousSceneID = previousSceneName = null;
        completionTime = 0.0;
    }
}
