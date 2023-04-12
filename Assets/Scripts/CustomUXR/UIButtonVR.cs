using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIButtonVR : MonoBehaviour
{
    public UnityEvent onPress;
    public UnityEvent onRelease;

    Collider presser;
 
    bool isPressed;
    bool enabled { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
        enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collider enter");
        if (!isPressed && enabled)
        {
            onPress.Invoke();
            presser = other;
            isPressed = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("collider exit");
        if (other == presser && enabled)
        {
            onRelease.Invoke();
            isPressed = false;
        }

    }

}


