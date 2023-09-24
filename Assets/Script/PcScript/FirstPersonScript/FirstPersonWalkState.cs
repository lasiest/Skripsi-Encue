public class FirstPersonWalkState : FirstPersonMovementStateTemplate
{
    public override void Execute() => fpc.PlayerMoveSpeed = playerWalkSpeed;
}