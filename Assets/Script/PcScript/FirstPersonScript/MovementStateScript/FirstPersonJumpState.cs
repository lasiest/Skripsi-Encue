using UnityEngine;

public class FirstPersonJumpState : FirstPersonMovementStateTemplate
{
    public FirstPersonJumpState(FirstPersonModel player, FirstPersonStateMachine stateMachine) : base(player, stateMachine) { }

    public override void Enter()
    {
        player.MoveSpeed = 1.5f * player.WalkSpeed * player.SpeedMultiplier;
        player._3DMovementDirectionY = Mathf.Sqrt(-2f * player.Gravity * player.JumpHeight);
    }

    public override void Execute()
    {
        if (player.IsGrounded) stateMachine.TransitionTo(stateMachine.WalkState);
        else return;
    }
}