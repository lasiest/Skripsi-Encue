using UnityEngine;

public class FirstPersonInput : MonoBehaviour
{
    [SerializeField] private FirstPersonModel player;

    public float GetAxisMouseX => Input.GetAxis("Mouse X");

    public float GetAxisMouseY => Input.GetAxis("Mouse Y");

    public float GetAxisHorizontal => Input.GetAxis("Horizontal");

    public float GetAxisVertical => Input.GetAxis("Vertical");

    public bool GetKeyLeftShift => Input.GetKey(KeyCode.LeftShift);

    public bool GetKeyDownE => Input.GetKeyDown(KeyCode.E);

    public bool GetKeyDownSpace => Input.GetKeyDown(KeyCode.Space);

    private void Update()
    {
        if (player.IsAllowedToMove && player.IsGrounded)
        {
            player.IsBeingOrderedToJump = GetKeyDownSpace;
            player.IsBeingOrderedToRun = GetKeyLeftShift;
        }
    }
}