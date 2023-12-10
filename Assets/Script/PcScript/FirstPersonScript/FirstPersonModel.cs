using UnityEngine;

public class FirstPersonModel : MonoBehaviour
{
    public IPlayerMovementState MovementState { get; set; }

    public IPlayerMovementState WalkState => walkState;

    public IPlayerMovementState RunState => runState;

    public IPlayerMovementState JumpState => jumpState;

    private readonly FirstPersonWalkState walkState = new();

    private readonly FirstPersonRunState runState = new();

    private readonly FirstPersonJumpState jumpState = new();

    public bool IsAllowedToMove { get; set; } = true;

    public bool IsAllowedToRun { get; set; } = true;

    public bool IsAllowedToJump { get; set; } = true;

    public bool IsBeingOrderedToRun => IsAllowedToRun && Input.GetKey(KeyCode.LeftShift);

    public bool IsGrounded => CharacterController.isGrounded;

    public bool IsBeingOrderedToJump => IsAllowedToJump && IsGrounded && Input.GetKeyDown(KeyCode.Space);

    public float MoveSpeed { get; set; }

    public FirstPersonMovementSpeedController MoveSpeedController => FindObjectOfType<FirstPersonMovementSpeedController>();

    public float MoveStrength => 2f;

    public float Gravity => -19.6f;

    public float MouseRotationSpeed => 1.75f;

    public float MainCameraXRotationAngle { get; set; }

    public float MainCameraXRotationAngleLimit => 90f;

    public Camera MainCamera { get; set; }

    public CharacterController CharacterController { get; set; }

    private Vector3 _3DmovementDirection;

    public Vector3 _3DMovementDirection
    {
        get => _3DmovementDirection;
        set => _3DmovementDirection = value;
    }

    public float _3DMovementDirectionY
    {
        get => _3DmovementDirection.y;
        set => _3DmovementDirection.y = value;
    }

    public float Current3DMovementDirectionY { get; set; }
}