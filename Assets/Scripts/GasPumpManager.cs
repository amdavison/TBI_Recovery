using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Manipulation;
using UnityEngine.UI;
using TMPro;

public class GasPumpManager : MonoBehaviour
{
    public TaskManager taskMan;

    public GameObject handle;
    public GameObject pumpOutline;
    public GameObject capOutline;

    public GameObject card;
    public GameObject cardOutline;

    public GameObject button;
    public GameObject buttonOutline;

    public TextMeshProUGUI price;
    public TextMeshProUGUI gallons;

    public UxrGrabbableObject cardGrab;
    public UxrGrabbableObject handleGrab;

    public Boolean filling = false;
    private float count = 0.0f;

    void Start()
    {

    }

    public void prepareCard()
    {
        cardGrab.IsGrabbable = true;
        handleGrab.IsGrabbable = false;
        button.GetComponent<ButtonVr>().enabled = false;
        cardOutline.SetActive(true);
    }
    public void prepareButton()
    {
        cardOutline.SetActive(false);
        button.GetComponent<ButtonVr>().enabled = true;
        cardGrab.IsGrabbable = false;
        buttonOutline.SetActive(true);
    }
    public void prepareHandle()
    {
        handleGrab.IsGrabbable = true;
        button.GetComponent<ButtonVr>().enabled = true;
        buttonOutline.SetActive(false);
        capOutline.SetActive(true);
    }
    public void prepareReplace()
    {
        pumpOutline.SetActive(true);
        capOutline.SetActive(false);
    }

    public void prepareEnd()
    {
        pumpOutline.SetActive(false);
        handleGrab.IsGrabbable = false;
    }
    public void pumpLifted()
    {
        filling = false;
        Debug.Log(filling);
    }
    public void pumpPlaced()
    {
        filling = true;
        Debug.Log(filling);
    }



    void Update()
    {
        if (filling)
        {
            if (count < 13.37)
            {
                price.text = (count * 3.39).ToString("0.00");
                gallons.text = (count).ToString("0.00");

                count += Time.deltaTime;

            }
            else
            {
                filling = false;
                Debug.Log("Time Done");
                taskMan.MarkTaskCompletion(5); 
            }
        }
    }
}
