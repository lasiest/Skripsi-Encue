public class FirstPersonRunState : FirstPersonMovementStateTemplate
{
    public FirstPersonRunState(FirstPersonModel player) : base(player) { }

    public override void Execute() => player.MoveSpeed = 2f * playerWalkSpeed;
}