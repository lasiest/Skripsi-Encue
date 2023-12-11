public interface IState<T>
{
    public abstract void Execute();

    public abstract T Transition();
}