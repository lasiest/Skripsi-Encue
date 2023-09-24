using UnityEngine;

public interface IGrabbable
{
    public abstract void BeingGrabbedOrReleased(bool isBeingGrabbed, Transform playerCrosshair);
}