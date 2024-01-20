using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] private FirstPersonInput input;

    [SerializeField] private FirstPersonModel player;

    [SerializeField] private GameObject playerGameobject;

    private readonly float mouseRotationSpeed = 1.75f;

    private readonly float xRotationAngleLimit = 90f;

    private float xRotationAngle;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (player.IsAllowedToMove)
        {
            xRotationAngle = Mathf.Clamp(xRotationAngle - input.GetAxisMouseY * mouseRotationSpeed, -xRotationAngleLimit, xRotationAngleLimit);
            transform.localRotation = Quaternion.Euler(xRotationAngle * Vector3.right);
            playerGameobject.transform.rotation *= Quaternion.Euler(input.GetAxisMouseX * mouseRotationSpeed * Vector3.up);
        }
    }
}