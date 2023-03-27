using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Manipulation;


public class GasTaskManager : TaskManager
{
    public int activityCount = 1;

    public GameObject handle;

    public GameObject card;

    public GasPumpManager gasMan;

    public AudioSource good;

    public override void MarkTaskCompletion(int taskID)
    {
        if (taskID != taskNum)
        {
            return;
        }

        if (taskID == 0)
        {
            gasMan.prepareCard();
            Debug.Log(taskID + " " + taskNum);

        }
        else if (taskID == 1)
        {
            good.Play();
            gasMan.prepareButton();
            Debug.Log(taskID + " " + taskNum);

        }
        else if (taskID == 2)
        {
            good.Play();
            gasMan.prepareHandle();
            Debug.Log(taskID + " " + taskNum);

        }
        else if(taskID == 3)
        {
            good.Play();
            Debug.Log(taskID + " " + taskNum);
        }
        else if (taskID == 4)
        {
            good.Play();
            gasMan.prepareReplace();
            Debug.Log(taskID + " " + taskNum);
            handle.GetComponent<UxrCustomInteractionEvents>().anchorTag = "GasPump";
        }
        else if (taskID == 5 && handle.GetComponent<UxrCustomInteractionEvents>().anchorTag == "GasPump")
        {
            good.Play();
            Debug.Log(taskID + " " + taskNum);
            activMan.MarkActivityCompletion();
        }

        base.MarkTaskCompletion(taskID);

    }

    void Start()
    {
        handle.GetComponent<UxrGrabbableObject>().IsGrabbable = false;
        card.GetComponent<UxrGrabbableObject>().IsGrabbable = false;
        MarkTaskCompletion(0);
    }

}
