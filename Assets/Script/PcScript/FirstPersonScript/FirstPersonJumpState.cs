using UnityEngine;

public class FirstPersonJumpState : FirstPersonMovementStateTemplate
{
    public override void Execute()
    {
        var playerJumpHeight = 1f;
        fpc.PlayerMoveSpeed = playerWalkSpeed;
        fpc.Player3DMovementDirectionY = fpc.PlayerCharacterController.velocity.y < -1f && fpc.IsPlayerGrounded ? 0f : fpc.CurrentPlayer3DMovementDirectionY;
        fpc.Player3DMovementDirectionY = fpc.IsOrderingPlayerToJump ? Mathf.Sqrt(-2f * fpc.PlayerGravity * playerJumpHeight) : fpc.CurrentPlayer3DMovementDirectionY;
    }

    public override IPlayerMovementState Transition()
    {
        Execute();
        return fpc.IsPlayerGrounded ? fpc.PlayerWalkState : fpc.PlayerJumpState;
    }
}