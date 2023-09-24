public class FirstPersonRunState : FirstPersonMovementStateTemplate
{
    public override void Execute() => fpc.PlayerMoveSpeed = 2f * playerWalkSpeed;
}