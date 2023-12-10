using UnityEngine;

public class FirstPersonJumpState : FirstPersonMovementStateTemplate
{
    public override void Execute()
    {
        var playerJumpHeight = 1f;
        player ??= Object.FindObjectOfType<FirstPersonModel>();
        player.MoveSpeed = 1.5f * playerWalkSpeed;
        player._3DMovementDirectionY = player.CharacterController.velocity.y < -1f && player.IsGrounded ? 0f : player.Current3DMovementDirectionY;
        player._3DMovementDirectionY = player.IsBeingOrderedToJump ? Mathf.Sqrt(-2f * player.Gravity * playerJumpHeight) : player.Current3DMovementDirectionY;
    }

    public override IPlayerMovementState Transition()
    {
        Execute();
        return player.IsGrounded ? player.WalkState : player.JumpState;
    }
}