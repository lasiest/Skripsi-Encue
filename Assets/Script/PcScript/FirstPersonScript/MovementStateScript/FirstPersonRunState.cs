public class FirstPersonRunState : FirstPersonMovementStateTemplate
{
    public override void Execute() => player.MoveSpeed = 2f * playerWalkSpeed;
}