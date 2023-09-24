public abstract class FirstPersonMovementStateTemplate : IPlayerMovementState
{
    protected FirstPersonController fpc = FirstPersonController.Instance;

    protected float playerWalkSpeed = 2f;

    public abstract void Execute();

    public virtual IPlayerMovementState Transition()
    {
        Execute();
        if (fpc.IsOrderingPlayerToJump)
        {
            fpc.PlayerJumpState.Execute();
            return fpc.PlayerJumpState;
        }
        else return fpc.IsOrderingPlayerToRun ? fpc.PlayerRunState : fpc.PlayerWalkState;
    }
}