using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActivityManager : MonoBehaviour
{
    //number of activities completed
    public TaskManager taskMan;
    public int activityCount { get; set; }

    public void MarkActivityCompletion()
    {
        // update activity count
        activityCount += 1;
    }

    protected abstract IEnumerator EndSimulation();
}
