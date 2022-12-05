using System.Threading.Tasks;
using Abstractions.Interfaces;
using Utils.Screens.Interfaces;

namespace Game.Bets.Interfaces
{
    public interface IBetScreen : IScreen, IResettable
    {
        Task<int> WaitForBet();
    }
}