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
    public GameObject staticCard;

    public GameObject button;
    public GameObject buttonOutline;

    public TextMeshProUGUI price;
    public TextMeshProUGUI gallons;

    public UxrGrabbableObject cardGrab;
    public UxrGrabbableObject handleGrab;

    public AudioSource done;
    public AudioSource fillingAudio;
    public AudioSource pickup;
    public AudioSource takeout;

    public Boolean filling = false;
    private float count = 0.0f;
    private Boolean fillingDone = false; 

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
        card.SetActive(false);
        staticCard.SetActive(true);
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
        takeout.Play();

        if (!fillingDone)
        {
            filling = false;
            capOutline.SetActive(true);
            Debug.Log(filling);
        }
    }
    public void pumpPlaced()
    {
        if (!fillingDone)
        {
            fillingAudio.Play();
            filling = true;
            capOutline.SetActive(false);
            Debug.Log(filling);
        }
    }



    void Update()
    {
        if (filling)
        {
            if (count < 35)
            {
                price.text = (count/2.6f * 3.39).ToString("0.00");
                gallons.text = (count/2.6f).ToString("0.00");

                count += Time.deltaTime;

            }
            else
            {
                filling = false;
                Debug.Log("Time Done");
                taskMan.MarkTaskCompletion(5);
                fillingDone = true;
                done.Play();
                fillingAudio.Stop();
            }
        }
    }
}
