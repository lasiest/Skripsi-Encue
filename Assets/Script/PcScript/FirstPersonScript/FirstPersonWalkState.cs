public class FirstPersonWalkState : FirstPersonMovementStateTemplate
{
    public override void Execute() => player.MoveSpeed = playerWalkSpeed;
}