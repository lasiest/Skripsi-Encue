using UnityEngine;

public abstract class FirstPersonMovementStateTemplate : IState<FirstPersonMovementStateTemplate>
{
    protected FirstPersonModel player;

    protected float playerWalkSpeed = 2f;

    public abstract void Execute();

    public virtual FirstPersonMovementStateTemplate Transition()
    {
        player ??= Object.FindObjectOfType<FirstPersonModel>();
        var movementStateFactory = player.MovementStateFactory;
        Execute();
        if (player.IsBeingOrderedToJump)
        {
            var jumpState = movementStateFactory.JumpState;
            jumpState.Execute();
            return jumpState;
        }
        else return player.IsBeingOrderedToRun ? movementStateFactory.RunState : movementStateFactory.WalkState;
    }
}