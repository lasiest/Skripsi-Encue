public class FirstPersonWalkState : FirstPersonMovementStateTemplate
{
    public FirstPersonWalkState(FirstPersonModel player) : base(player) { }

    public override void Execute() => player.MoveSpeed = playerWalkSpeed;
}