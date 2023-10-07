public abstract class FirstPersonMovementStateTemplate : IPlayerMovementState
{
    protected FirstPersonModel player = FirstPersonModel.Instance;

    protected float playerWalkSpeed = 2f;

    public abstract void Execute();

    public virtual IPlayerMovementState Transition()
    {
        Execute();
        if (player.IsBeingOrderedToJump)
        {
            player.JumpState.Execute();
            return player.JumpState;
        }
        else return player.IsBeingOrderedToRun ? player.RunState : player.WalkState;
    }
}