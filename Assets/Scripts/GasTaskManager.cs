using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Manipulation;


public class GasTaskManager : TaskManager
{
    public int activityCount = 1;

    public GameObject handle;
    public GameObject card;

    public override void MarkTaskCompletion(int taskID)
    {
        if (taskID != taskNum)
        {
            return;
        }


        if (taskID == 0)
        {
            Debug.Log(taskID + " " + taskNum);

        }
        else if (taskID == 1)
        {
            Debug.Log(taskID + " " + taskNum);

        }
        else if (taskID == 2)
        {
            Debug.Log(taskID + " " + taskNum);

        }
        else if(taskID == 3)
        {
            Debug.Log(taskID + " " + taskNum);
        }
        else if (taskID == 4)
        {
            Debug.Log(taskID + " " + taskNum);
            handle.GetComponent<UxrCustomInteractionEvents>().anchorTag = "GasPump";
        }
        else if (taskID == 5 && handle.GetComponent<UxrCustomInteractionEvents>().anchorTag == "GasPump")
        {
            Debug.Log(taskID + " " + taskNum);
        }

        base.MarkTaskCompletion(taskID);

    }
    private void InitializeScene()
    {
        handle.GetComponent<UxrGrabbableObject>().IsGrabbable = false;
        card.GetComponent<UxrGrabbableObject>().IsGrabbable = false;

    }
}
