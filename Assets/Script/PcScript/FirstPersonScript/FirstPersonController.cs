using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    private FirstPersonModel player;

    private void Setup()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player = FirstPersonModel.Instance;
        player.CharacterController = GetComponent<CharacterController>();
        player.MainCamera = GetComponentInChildren<Camera>();
    }
    
    private void Start()
    {
        Setup();
        InitiateMovementState();
    }

    private void InitiateMovementState()
    {
        var movementStateFactory = player.MovementStateFactory;
        movementStateFactory.WalkState = movementStateFactory.Produce(FirstPersonMovementState.Walk);
        movementStateFactory.JumpState = movementStateFactory.Produce(FirstPersonMovementState.Jump);
        movementStateFactory.RunState = movementStateFactory.Produce(FirstPersonMovementState.Run);
        player.MovementState = movementStateFactory.WalkState;
    }

    private void Update()
    {
        if (player.IsAllowedToMove)
        {
            player.MovementState = player.MovementState.Transition();
            player.MainCameraXRotationAngle = Mathf.Clamp(player.MainCameraXRotationAngle - Input.GetAxis("Mouse Y") * player.MouseRotationSpeed, -player.MainCameraXRotationAngleLimit, player.MainCameraXRotationAngleLimit);
            player.MainCamera.transform.localRotation = Quaternion.Euler(player.MainCameraXRotationAngle * Vector3.right);
            transform.rotation *= Quaternion.Euler(Input.GetAxis("Mouse X") * player.MouseRotationSpeed * Vector3.up);
            ResetCurrentPlayer3DMovementDirectionY();
            var decreasedMoveSpeed = player.MoveSpeed - player.MoveSpeedController.DecreasedMoveSpeed;
            player._3DMovementDirection = transform.TransformDirection(Input.GetAxis("Vertical") * decreasedMoveSpeed * Vector3.forward) + transform.TransformDirection(Input.GetAxis("Horizontal") * decreasedMoveSpeed * Vector3.right);
            player._3DMovementDirectionY = player.Current3DMovementDirectionY;
            player._3DMovementDirectionY += player.IsGrounded ? 0f : player.Gravity * Time.deltaTime;
            ResetCurrentPlayer3DMovementDirectionY();
            player.CharacterController.Move(player._3DMovementDirection * Time.deltaTime);
        }
    }

    private void ResetCurrentPlayer3DMovementDirectionY() => player.Current3DMovementDirectionY = player._3DMovementDirectionY;
}