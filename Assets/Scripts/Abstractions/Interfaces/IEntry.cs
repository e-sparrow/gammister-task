namespace Abstractions.Interfaces
{
    public interface IEntry
    {
        void Install();

        bool IsEnabled
        {
            get;
        }
    }
}