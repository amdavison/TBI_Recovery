using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Manipulation;
using UnityEngine.SceneManagement;


public class GasTaskManager : TaskManager
{
    public int activityCount = 1;

    public GameObject handle;

    public GameObject card;

    public GasPumpManager gasMan;

    public AudioSource good;
    public AudioSource end;
    public GameObject[] videoInstructions;
    public SceneChanger scenChang;


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
            videoInstructions[0].SetActive(false);
            videoInstructions[1].SetActive(true);
            StartCoroutine(EndSimulation());

        }
        else if (taskID == 1)
        {
            good.Play();
            gasMan.prepareButton();
            Debug.Log(taskID + " " + taskNum);
            videoInstructions[1].SetActive(false);
            videoInstructions[2].SetActive(true);

        }
        else if (taskID == 2)
        {
            good.Play();
            gasMan.prepareHandle();
            Debug.Log(taskID + " " + taskNum);
            videoInstructions[2].SetActive(false);
            videoInstructions[3].SetActive(true);
        }
        else if(taskID == 3)
        {
            good.Play();
            Debug.Log(taskID + " " + taskNum);
            videoInstructions[3].SetActive(false);
            videoInstructions[4].SetActive(true);
        }
        else if (taskID == 4)
        {
            good.Play();
            gasMan.filling = true;
            Debug.Log(taskID + " " + taskNum);
        } 
        else if (taskID == 5)
        {
            good.Play();
            Debug.Log(taskID + " " + taskNum);
            gasMan.prepareReplace();
            handle.GetComponent<UxrCustomInteractionEvents>().anchorTag = "GasPump";
            videoInstructions[4].SetActive(false);
            videoInstructions[5].SetActive(true);
        }

        else if (taskID == 6 && handle.GetComponent<UxrCustomInteractionEvents>().anchorTag == "GasPump")
        {
            end.Play();
            Debug.Log(taskID + " " + taskNum);
            gasMan.prepareEnd();
            activMan.MarkActivityCompletion();
            videoInstructions[5].SetActive(false);
            videoInstructions[6].SetActive(true);
            StartCoroutine(EndSimulation());
        }

        base.MarkTaskCompletion(taskID);

    }

    void Start()
    {
        handle.GetComponent<UxrGrabbableObject>().IsGrabbable = false;
        card.GetComponent<UxrGrabbableObject>().IsGrabbable = false;
        MarkTaskCompletion(0);
    }

    IEnumerator EndSimulation()
    {
        LevelComplete.previousSceneID = "gasStation";
        LevelComplete.previousSceneName = "Gas Station";
        yield return new WaitForSecondsRealtime(3);
        scenChang.changeScene("LevelCompletion");
    }
}
