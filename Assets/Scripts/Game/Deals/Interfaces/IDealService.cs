using System.Threading.Tasks;

namespace Game.Deals.Interfaces
{
    public interface IDealService
    {
        Task<IDealResult> Deal(int bet);
    }
}