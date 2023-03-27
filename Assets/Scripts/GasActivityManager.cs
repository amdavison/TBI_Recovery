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

        if (activityCount == 1 || true)
        {
            EndSimulation();
        }
    }

    protected override IEnumerator EndSimulation()
    {
        // just loads the main scene
        yield return new WaitForSecondsRealtime(5);
        EndAudio.Play();
        yield return new WaitForSecondsRealtime(5);
        //SceneManager.LoadScene("Main");
    }
}
