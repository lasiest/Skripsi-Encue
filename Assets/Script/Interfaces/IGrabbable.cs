using UnityEngine;

public interface IGrabbable
{
    public abstract float Weight { get; }

    public abstract void BeingGrabbedOrReleased(bool isBeingGrabbed, Transform playerCrosshair);
}