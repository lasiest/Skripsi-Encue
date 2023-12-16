public interface IFactory<TReturn, TEnum>
{
    public abstract TReturn Produce(TEnum tEnum);
}