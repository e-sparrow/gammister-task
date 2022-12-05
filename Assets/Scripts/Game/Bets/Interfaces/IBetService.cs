using System.Threading.Tasks;

namespace Game.Bets.Interfaces
{
    public interface IBetService
    {
        Task<int> GetBet();
    }
}