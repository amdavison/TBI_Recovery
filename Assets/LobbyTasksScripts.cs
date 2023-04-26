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
    public GameObject cmTutorialVid;
    public GameObject pbTutorialButton;
    public GameObject gasTutorialButton;
    public GameObject cardsTutorialButton;
    public VideoPlayer pbvideoPlayer;
    public VideoPlayer cmvideoPlayer;



    // Start is called before the first frame update
    void Start()
    {

    }

    public void cardButtonConfirm()
    {
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
        TBIRStitle.SetActive(false);
        confirmTitle.SetActive(true);
        cardButton.SetActive(false);
        gasButton.SetActive(false);
        pbButton.SetActive(false);
        gasConfirm.SetActive(true);
        returnButton.SetActive(true);

    }

    public void pbButtonConfirm()
    {
        TBIRStitle.SetActive(false);
        confirmTitle.SetActive(true);
        cardButton.SetActive(false);
        gasButton.SetActive(false);
        pbButton.SetActive(false);
        pbConfirm.SetActive(true);
        returnButton.SetActive(true);

    }

    public void cancelButton()
    {
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

    public void cmTutorial()
    {
        TBIRStitle.SetActive(false);
        cardButton.SetActive(false);
        gasButton.SetActive(false);
        pbButton.SetActive(false);
        pbTutorialButton.SetActive(false);
        gasTutorialButton.SetActive(false);
        cardsTutorialButton.SetActive(false);
        cmTutorialVid.SetActive(true);
        cmvideoPlayer.Play();
        returnButton.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
