using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class HandAndRayManager : MonoBehaviour
{
    public XRRayInteractor rRay;
    public XRRayInteractor lRay;

    public void rHandGrab(){
        rRay.enabled = false;
    }
    public void rHandRelease(){
        rRay.enabled = true;
    }
    public void lHandGrab(){
        lRay.enabled = false;
    }
    public void lHandRelease(){
        lRay.enabled = true;
    }

}
