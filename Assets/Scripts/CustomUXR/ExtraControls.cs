using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Avatar;
using UltimateXR.Devices;
using UnityEngine.SceneManagement;
using UltimateXR.Core;


public class ExtraControls : MonoBehaviour
{
    [SerializeField] private GameObject instructionCanvas;

    private bool deactivated;



    void Start()
    {
        deactivated = true;
    }



    
    void Update()
    {
        if (UxrAvatar.LocalAvatarInput.GetButtonsPressUp(UxrHandSide.Left, UxrInputButtons.Menu))
        {
            Debug.Log("Menu press");
            instructionCanvas.SetActive(deactivated);
            deactivated = !deactivated;
        }
    }
}
