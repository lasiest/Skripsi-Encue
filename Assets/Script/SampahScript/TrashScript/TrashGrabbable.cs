using UnityEngine;

public class TrashGrabbable : Trash, IGrabbable
{
    [SerializeField] private float lerpMultiplier = 100f;

    private Transform crosshair;

    public float Weight => sampahInformation.beratSampah;

    public void BeingGrabbedOrReleased(bool isBeingGrabbed, Transform playerCrosshair)
    {
        crosshair = playerCrosshair;
        rigidBody.useGravity = !isBeingGrabbed;
        rigidBody.isKinematic = isBeingGrabbed;
    }

    private void Update()
    {
        if (crosshair != null)
        {
            Vector3 smoothedGrabPosition = Vector3.Lerp(transform.position, crosshair.position, lerpMultiplier * Time.deltaTime);
            rigidBody.MovePosition(smoothedGrabPosition);
        }
    }
}