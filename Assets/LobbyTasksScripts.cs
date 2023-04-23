using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        gasConfirm.SetActive(false);
        cardConfirm.SetActive(false);
        pbConfirm.SetActive(false);
        returnButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
