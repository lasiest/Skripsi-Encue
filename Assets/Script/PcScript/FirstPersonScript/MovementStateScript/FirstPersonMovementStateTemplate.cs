using UnityEngine;

public abstract class FirstPersonMovementStateTemplate : IState<FirstPersonMovementStateTemplate>
{
    protected FirstPersonModel player;

    protected float playerWalkSpeed = 2f * PlayerPrefs.GetFloat(PlayerPrefsKey.MOVEMENT_SPEED_MULTIPLIER, 1f);

    protected FirstPersonMovementStateTemplate(FirstPersonModel player) => this.player = player;

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