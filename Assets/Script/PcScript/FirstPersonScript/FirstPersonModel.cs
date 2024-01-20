using UnityEngine;

public class FirstPersonModel : Singleton<FirstPersonModel>
{
    [SerializeField] private CharacterController characterController;

    [SerializeField] private bool isAllowedToMove = true;

    [SerializeField] private float moveSpeed;

    [SerializeField] private float walkSpeed = 2f;

    [SerializeField] private float jumpHeight = 1f;

    [SerializeField] private float gravity = -19.6f;

    [SerializeField] private Vector3 _3DmovementDirection;

    public CharacterController CharacterController => characterController;

    public bool IsGrounded => CharacterController.isGrounded;

    public bool IsAllowedToMove { get => isAllowedToMove; set => isAllowedToMove = value; }

    public bool IsBeingOrderedToRun { get; set; }

    public bool IsBeingOrderedToJump { get; set; }

    public bool HasGrabbed { get; set; }

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    public float WalkSpeed => walkSpeed;

    public float JumpHeight => jumpHeight;

    public float Gravity => gravity;

    public float SpeedMultiplier => GameData.Instance.PlayerSpeedMultiplier;

    public float StrengthMultiplier => GameData.Instance.PlayerStrengthMultiplier;

    public Vector3 _3DMovementDirection { get => _3DmovementDirection; set => _3DmovementDirection = value; }

    public float _3DMovementDirectionY { get => _3DmovementDirection.y; set => _3DmovementDirection.y = value; }
}