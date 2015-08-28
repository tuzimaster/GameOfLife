namespace GameOfLife.Domain.Infrastructure
{
    public interface IExecutor<T>
    {
        T Execute(T rule);
        void Register(IExecutor<T> next);
    }
}
