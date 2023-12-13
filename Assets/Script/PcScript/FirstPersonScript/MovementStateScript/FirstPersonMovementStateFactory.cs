public class FirstPersonMovementStateFactory : IFactory<FirstPersonMovementStateTemplate, FirstPersonModel, FirstPersonMovementState>
{
    public FirstPersonMovementStateTemplate WalkState { get; set; }

    public FirstPersonMovementStateTemplate RunState { get; set; }

    public FirstPersonMovementStateTemplate JumpState { get; set; }

    public FirstPersonMovementStateTemplate Produce(FirstPersonModel client, FirstPersonMovementState stateType)
        => stateType switch
        {
            FirstPersonMovementState.Run => new FirstPersonRunState(client),
            FirstPersonMovementState.Jump => new FirstPersonJumpState(client),
            _ => new FirstPersonWalkState(client),
        };
}