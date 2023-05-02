using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GasActivityManager : ActivityManager
{
    //number of activities completed
    public AudioSource EndAudio;

    public void MarkActivityCompletion()
    {
        base.MarkActivityCompletion();
        Debug.Log("activity completed");
        if (activityCount == 1 || true)
        {
            Debug.Log("finished");
            StartCoroutine(EndSimulation());
        }
    }

    protected override IEnumerator EndSimulation()
    {
        LevelComplete.previousSceneID = "gasStation";
        LevelComplete.previousSceneName = "Gas Station";
        // just loads the main scene
        yield return new WaitForSecondsRealtime(5);
        EndAudio.Play();
        Debug.Log("Sound");
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene("LevelCompletion");
        Debug.Log("loading scene?");
    }
}
