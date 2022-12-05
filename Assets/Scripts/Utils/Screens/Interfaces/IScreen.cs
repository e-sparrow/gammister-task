namespace Utils.Screens.Interfaces
{
    public interface IScreen : IShowable, IHiddable
    {

    }

    public interface IScreen<in TArgument> : IShowable<TArgument>, IHiddable
    {
        
    }
}