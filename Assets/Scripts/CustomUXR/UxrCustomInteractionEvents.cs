using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UltimateXR.Manipulation;
using UltimateXR.Core.Components.Composite;


class UxrCustomInteractionEvents : UxrGrabbableObjectComponent<UxrCustomInteractionEvents>
{
    public UnityEvent onGrab;
    public UnityEvent whileGrabbing;
    public UnityEvent whileReleasing;
    public UnityEvent onRelease;    
    public UnityEvent whilePlacing;
    public UnityEvent onPlaced;
    public string anchorTag;
    public UnityEvent onSpecificPlaced;
    public UnityEvent whileConstraintsApplying;
    public UnityEvent onConstraintsApplied;




    protected override void OnObjectGrabbing(UxrManipulationEventArgs e)
    {
        whileGrabbing.Invoke();
    }

    protected override void OnObjectGrabbed(UxrManipulationEventArgs e)
    {
        onGrab.Invoke();
    }

    protected override void OnObjectReleasing(UxrManipulationEventArgs e)
    {
        whileReleasing.Invoke();
    }

    protected override void OnObjectReleased(UxrManipulationEventArgs e)
    {
        onRelease.Invoke();
    }

    protected override void OnObjectPlacing(UxrManipulationEventArgs e)
    {
        whilePlacing.Invoke();
    }

    protected override void OnObjectPlaced(UxrManipulationEventArgs e)
    {
        if (e.GrabbableAnchor.tag == anchorTag)
        {
            onSpecificPlaced.Invoke();
        }
        else
        {
            onPlaced.Invoke();
        }
    }

    protected override void OnObjectConstraintsApplying(UxrApplyConstraintsEventArgs e)
    {
        whileConstraintsApplying.Invoke();
    }

    protected override void OnObjectConstraintsApplied(UxrApplyConstraintsEventArgs e)
    {
        onConstraintsApplied.Invoke();
    }
}
