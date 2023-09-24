public interface IPlayerMovementState 
{
    public abstract void Execute();

    public abstract IPlayerMovementState Transition();
}