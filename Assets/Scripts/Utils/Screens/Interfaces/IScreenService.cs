namespace Utils.Screens.Interfaces
{
    public interface IScreenService
    {
        void ShowScreen(IScreen screen);
        void ShowScreen<TArgument>(IScreen<TArgument> screen, TArgument argument);

        void Back();
        void Hide();
    }
}