using UnityEngine;

public abstract class FirstPersonMovementStateTemplate : IState<FirstPersonMovementStateTemplate>
{
    protected FirstPersonModel player = FirstPersonModel.Instance;

    protected float playerWalkSpeed = 2f * GameData.Instance.PlayerSpeedMultiplier;

    public abstract void Execute();

    public virtual FirstPersonMovementStateTemplate Transition()
    {
        Execute();
        var movementStateFactory = player.MovementStateFactory;
        if (player.IsBeingOrderedToJump)
        {
            var jumpState = movementStateFactory.JumpState;
            jumpState.Execute();
            return jumpState;
        }
        else return player.IsBeingOrderedToRun ? movementStateFactory.RunState : movementStateFactory.WalkState;
    }
}