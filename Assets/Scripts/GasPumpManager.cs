using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Manipulation;
using TMPro;

public class GasPumpManager : MonoBehaviour
{
    public GameObject handle;
    public GameObject pumpOutline;
    public GameObject capOutline;

    public GameObject card;
    public GameObject cardOutline;

    public GameObject button;
    public GameObject buttonOutline;

    public TextMeshPro price;
    public TextMeshPro gallons;

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

    public IEnumerator GasCountdown()
    {
        float count = 0.0f;
        while (count < 20)
        {
            count += Time.deltaTime;
            Debug.Log(count);
            price.text = $"{count*3.39:0.##}";
            gallons.text = $"{count:0.##}";
        }
        yield return null;

    }
}
