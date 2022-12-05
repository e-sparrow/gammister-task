namespace Utils.Screens.Interfaces
{
    public interface IShowable
    {
        void Show();
    }

    public interface IShowable<in TArgument>
    {
        void Show(TArgument argument);
    }
}