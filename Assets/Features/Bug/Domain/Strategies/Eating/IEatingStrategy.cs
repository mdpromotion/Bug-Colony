namespace Bug.Domain
{
    public interface IEatingStrategy
    {
        void Eat(Bug bug, object food);
    }
}