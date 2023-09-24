using UnityEngine;

public class FirstPersonController : Singleton<FirstPersonController>
{
    private IPlayerMovementState playerMovementState;

    public IPlayerMovementState PlayerWalkState => new FirstPersonWalkState();

    public IPlayerMovementState PlayerRunState => new FirstPersonRunState();

    public IPlayerMovementState PlayerJumpState => new FirstPersonJumpState();

    public bool AllowPlayerToMove { get; set; } = true;

    public bool AllowPlayerToRun { get; set; } = true;

    public bool AllowPlayerToJump { get; set; } = true;

    public bool IsOrderingPlayerToRun => AllowPlayerToRun && Input.GetKey(KeyCode.LeftShift);

    public bool IsPlayerGrounded => PlayerCharacterController.isGrounded;

    public bool IsOrderingPlayerToJump => AllowPlayerToJump && IsPlayerGrounded && Input.GetKeyDown(KeyCode.Space);

    public float PlayerMoveSpeed { private get; set; }

    public float PlayerGravity => -19.6f;

    private readonly float mouseRotationSpeed = 1.75f;

    private float mainCameraXRotationAngle;

    private readonly float mainCameraXRotationAngleLimit = 90f;

    private Camera mainCamera;

    public CharacterController PlayerCharacterController { get; set; }

    private Vector3 player3DMovementDirection;

    public float Player3DMovementDirectionY { set => player3DMovementDirection.y = value; }

    public float CurrentPlayer3DMovementDirectionY { get; set; }

    private void Start()
    {
        playerMovementState = PlayerWalkState;
        mainCamera = GetComponentInChildren<Camera>();
        PlayerCharacterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void ResetCurrentPlayer3DMovementDirectionY() => CurrentPlayer3DMovementDirectionY = player3DMovementDirection.y;

    private void Update()
    {
        if (AllowPlayerToMove)
        {
            playerMovementState = playerMovementState.Transition();
            mainCameraXRotationAngle = Mathf.Clamp(mainCameraXRotationAngle - Input.GetAxis("Mouse Y") * mouseRotationSpeed, -mainCameraXRotationAngleLimit, mainCameraXRotationAngleLimit);
            mainCamera.transform.localRotation = Quaternion.Euler(mainCameraXRotationAngle * Vector3.right);
            transform.rotation *= Quaternion.Euler(Input.GetAxis("Mouse X") * mouseRotationSpeed * Vector3.up);
            ResetCurrentPlayer3DMovementDirectionY();
            player3DMovementDirection = transform.TransformDirection(Input.GetAxis("Vertical") * PlayerMoveSpeed * Vector3.forward) + transform.TransformDirection(Input.GetAxis("Horizontal") * PlayerMoveSpeed * Vector3.right);
            player3DMovementDirection.y = CurrentPlayer3DMovementDirectionY;
            player3DMovementDirection.y += IsPlayerGrounded ? 0f : PlayerGravity * Time.deltaTime;
            ResetCurrentPlayer3DMovementDirectionY();
            PlayerCharacterController.Move(player3DMovementDirection * Time.deltaTime);
        }
    }
}