using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Manipulation;


public class GasPumpManager : MonoBehaviour
{
    public GameObject handle;
    public GameObject pumpOutline;
    public GameObject capOutline;

    public GameObject card;
    public GameObject cardOutline;

    public GameObject button;
    public GameObject buttonOutline;

    public UxrGrabbableObject cardGrab;
    public UxrGrabbableObject handleGrab;

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
}
