public class FirstPersonRunState : FirstPersonMovementStateTemplate
{
    public FirstPersonRunState(FirstPersonModel player, FirstPersonStateMachine stateMachine) : base(player, stateMachine) { }

    public override void Enter() => player.MoveSpeed = 2f * player.WalkSpeed * player.SpeedMultiplier;

    public override void Execute()
    {
        if (player.IsBeingOrderedToJump) stateMachine.TransitionTo(stateMachine.JumpState);
        else if (player.IsBeingOrderedToRun) return;
        else stateMachine.TransitionTo(stateMachine.WalkState);
    }
}