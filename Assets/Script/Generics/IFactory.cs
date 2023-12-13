public interface IFactory<TReturn, TClient, TEnum>
{
    public abstract TReturn Produce(TClient tClient, TEnum tEnum);
}