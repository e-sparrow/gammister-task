namespace Abstractions.Interfaces
{
    public interface IFactory<out T>
    {
        T Create();
    }
}