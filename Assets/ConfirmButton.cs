using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmButton : MonoBehaviour
{
    public SceneChanger sceneMan;
    public GameObject confirm;
    public GameObject regButton;
    public GameObject cancel;

    public void StartConfirm()
    {
        regButton.SetActive(false);
        confirm.SetActive(true);
        cancel.SetActive(true);
    }

    public void Confirm()
    {
        sceneMan.changeScene("Lobby");
    }

    public void Cancel()
    {
        regButton.SetActive(true);
        confirm.SetActive(false);
        cancel.SetActive(false);
    }
}
