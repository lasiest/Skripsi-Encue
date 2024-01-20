public class FirstPersonWalkState : FirstPersonMovementStateTemplate
{
    public FirstPersonWalkState(FirstPersonModel player, FirstPersonStateMachine stateMachine) : base(player, stateMachine) { }

    public override void Enter() => player.MoveSpeed = player.WalkSpeed * player.SpeedMultiplier;

    public override void Execute()
    {
        if (player.IsBeingOrderedToJump) stateMachine.TransitionTo(stateMachine.JumpState);
        else if (player.IsBeingOrderedToRun) stateMachine.TransitionTo(stateMachine.RunState);
        else return;
    }
}