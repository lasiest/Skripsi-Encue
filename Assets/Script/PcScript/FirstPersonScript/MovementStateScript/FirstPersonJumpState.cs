using UnityEngine;

public class FirstPersonJumpState : FirstPersonMovementStateTemplate
{
    public override void Execute()
    {
        var playerJumpHeight = 1f;
        player ??= Object.FindObjectOfType<FirstPersonModel>();
        player.MoveSpeed = 1.5f * playerWalkSpeed;
        var playerCurrent3DMovementDirectionY = player.Current3DMovementDirectionY;
        player._3DMovementDirectionY = player.CharacterController.velocity.y < -1f && player.IsGrounded ? 0f : playerCurrent3DMovementDirectionY;
        player._3DMovementDirectionY = player.IsBeingOrderedToJump ? Mathf.Sqrt(-2f * player.Gravity * playerJumpHeight) : playerCurrent3DMovementDirectionY;
    }

    public override FirstPersonMovementStateTemplate Transition()
    {
        Execute();
        var movementStateFactory = player.MovementStateFactory;
        return player.IsGrounded ? movementStateFactory.WalkState : movementStateFactory.JumpState;
    }
}