public class FirstPersonMovementStateFactory : IFactory<FirstPersonMovementStateTemplate, FirstPersonMovementState>
{
    public FirstPersonMovementStateTemplate WalkState { get; set; }

    public FirstPersonMovementStateTemplate RunState { get; set; }

    public FirstPersonMovementStateTemplate JumpState { get; set; }

    public FirstPersonMovementStateTemplate Produce(FirstPersonMovementState stateType)
        => stateType switch
        {
            FirstPersonMovementState.Run => new FirstPersonRunState(),
            FirstPersonMovementState.Jump => new FirstPersonJumpState(),
            _ => new FirstPersonWalkState(),
        };
}