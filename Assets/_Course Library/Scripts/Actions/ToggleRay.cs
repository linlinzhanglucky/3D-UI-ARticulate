﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Toggle between the direct and ray interactor if the direct interactor isn't touching any objects
/// Should be placed on a ray interactor
/// </summary>
[RequireComponent(typeof(XRRayInteractor))]
public class ToggleRay : MonoBehaviour
{
    [Tooltip("Switch even if an object is selected")]
    public bool forceToggle = false;

    [Tooltip("The direct interactor that's switched to")]
    public XRDirectInteractor directInteractor = null;

    private XRRayInteractor rayInteractor = null;
    private bool isRay = true;

    private void Awake()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
        SwitchInteractors(false);
    }

    public void ToggleRayInteractor() 
    {
        if (!isRay) {
            ActivateRay(); 
        } else {
            DeactivateRay(); 
        }
    }

    public void ActivateRay()
    {
        SwitchInteractors(true);
    }

    public void DeactivateRay()
    {
        SwitchInteractors(false);
    }

    private bool TouchingObject()
    {
        List<IXRInteractable> targets = new List<IXRInteractable>();
        directInteractor.GetValidTargets(targets);
        return (targets.Count > 0);
    }

    private void SwitchInteractors(bool value)
    {
        isRay = value;
        rayInteractor.enabled = value;
        // directInteractor.enabled = !value;
    }
}
