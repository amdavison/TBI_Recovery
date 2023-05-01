using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class LobbyTasksScripts : MonoBehaviour
{

    public GameObject cardButton;
    public GameObject gasButton;
    public GameObject pbButton;
    public GameObject returnButton;
    public GameObject TBIRStitle;
    public GameObject confirmTitle;
    public GameObject cardConfirm;
    public GameObject gasConfirm;
    public GameObject pbConfirm;
    public GameObject pbTutorialVid;
    public GameObject pbTutorialButton;
    public GameObject gasTutorialButton;
    public GameObject cardsTutorialButton;
    public VideoPlayer pbvideoPlayer;
    public VideoPlayer gasVideoPlayer;

    private bool pressed = false;

    public void cardButtonConfirm()
    {
        if (pressed)
        {
            return;
        }
        pressed = true;
        StartCoroutine(PressCooldown());

        TBIRStitle.SetActive(false);
        confirmTitle.SetActive(true);
        cardButton.SetActive(false);
        gasButton.SetActive(false);
        pbButton.SetActive(false);
        cardConfirm.SetActive(true);
        returnButton.SetActive(true);
    }

    public void gasButtonConfirm()
    {
        if (pressed)
        {
            return;
        }
        pressed = true;
        StartCoroutine(PressCooldown());

        TBIRStitle.SetActive(false);
        confirmTitle.SetActive(true);
        cardButton.SetActive(false);
        gasButton.SetActive(false);
        pbButton.SetActive(false);
        gasConfirm.SetActive(true);
        returnButton.SetActive(true);
        pbTutorialButton.SetActive(false);
        gasTutorialButton.SetActive(false);
        cardsTutorialButton.SetActive(false);
        StartCoroutine(PressCooldown());
    }

    public void pbButtonConfirm()
    {
        if (pressed)
        {
            return;
        }
        pressed = true;
        StartCoroutine(PressCooldown());

        TBIRStitle.SetActive(false);
        confirmTitle.SetActive(true);
        cardButton.SetActive(false);
        gasButton.SetActive(false);
        pbButton.SetActive(false);
        pbConfirm.SetActive(true);
        returnButton.SetActive(true);
        pbTutorialButton.SetActive(false);
        gasTutorialButton.SetActive(false);
        cardsTutorialButton.SetActive(false);
    }

    public void cancelButton()
    {
        if (pressed)
        {
            return;
        }
        pressed = true;
        StartCoroutine(PressCooldown());

        TBIRStitle.SetActive(true);
        confirmTitle.SetActive(false);
        cardButton.SetActive(true);
        gasButton.SetActive(true);
        pbButton.SetActive(true);
        pbTutorialButton.SetActive(true);
        gasTutorialButton.SetActive(true);
        cardsTutorialButton.SetActive(true);
        gasConfirm.SetActive(false);
        cardConfirm.SetActive(false);
        pbConfirm.SetActive(false);
        pbTutorialVid.SetActive(false);
        returnButton.SetActive(false);
    }

    public void pbTutorial()
    {
        if (pressed)
        {
            return;
        }
        pressed = true;
        StartCoroutine(PressCooldown());

        TBIRStitle.SetActive(false);
        cardButton.SetActive(false);
        gasButton.SetActive(false);
        pbButton.SetActive(false);
        pbTutorialButton.SetActive(false);
        gasTutorialButton.SetActive(false);
        cardsTutorialButton.SetActive(false);
        pbTutorialVid.SetActive(true);
        pbvideoPlayer.Play();
        returnButton.SetActive(true);
    }

    public void gasTutorial()
    {
        if (pressed)
        {
            return;
        }
        pressed = true;
        StartCoroutine(PressCooldown());

        TBIRStitle.SetActive(false);
        cardButton.SetActive(false);
        gasButton.SetActive(false);
        pbButton.SetActive(false);
        pbTutorialButton.SetActive(false);
        gasTutorialButton.SetActive(false);
        cardsTutorialButton.SetActive(false);
        pbTutorialVid.SetActive(true);
        gasVideoPlayer.Play();
        returnButton.SetActive(true);
    }

    IEnumerator PressCooldown()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        pressed = false;
    }
}
