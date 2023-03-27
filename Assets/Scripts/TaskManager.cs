using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TaskManager : MonoBehaviour
{
    public ActivityManager activMan;
    public InstructionUpdater instrUpdater;

    public int taskNum { get; set; }
    public int activityCount { get; set; }

    public virtual void MarkTaskCompletion(int taskID)
    {
        //mark time and increment task count
        taskNum += 1;
        Debug.Log("The task count is, " + (taskNum));

        instrUpdater.RunInstructions();
    }
}
