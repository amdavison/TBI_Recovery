using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVr : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;


    Collider presser;
 
    bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collider enter");
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0.008f, 0, 0);
            onPress.Invoke();
            presser = other;
            isPressed = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("collider exit");
        if (other == presser)
        {
            button.transform.localPosition = new Vector3(0, 0, 0);
            onRelease.Invoke();
            isPressed = false;
        }

    }

}


