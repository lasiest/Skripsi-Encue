using UnityEngine;

public class FirstPersonStateMachine : MonoBehaviour
{
    [SerializeField] private FirstPersonModel player;

    private FirstPersonWalkState walkState;

    public FirstPersonRunState runState;

    public FirstPersonJumpState jumpState;

    private IState currentState;

    public IState WalkState => walkState;

    public IState RunState => runState;

    public IState JumpState => jumpState;

    private void Start()
    {
        walkState = new(player, stateMachine: this);
        runState = new(player, stateMachine: this);
        jumpState = new(player, stateMachine: this);
        TransitionTo(walkState);
    }

    public void TransitionTo(IState nextState)
    {
        currentState = nextState;
        nextState.Enter();
    }

    private void Update() { if (player.IsAllowedToMove) currentState.Execute(); }
}