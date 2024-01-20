public abstract class FirstPersonMovementStateTemplate : IState
{
    protected FirstPersonModel player;

    protected FirstPersonStateMachine stateMachine;

    protected FirstPersonMovementStateTemplate(FirstPersonModel player, FirstPersonStateMachine stateMachine)
    {
        this.player = player;
        this.stateMachine = stateMachine;
    }

    public abstract void Enter();

    public abstract void Execute();
}