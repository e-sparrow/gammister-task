using System.Threading.Tasks;
using Abstractions.Interfaces;
using Game.Combinations.Enums;
using Utils.Screens.Interfaces;

namespace Game.Deals.Interfaces
{
    public interface IDealScreen : IScreen, IResettable
    {
        Task WaitForApply();
        Task WaitForNext();
        
        void SetSwitches(int amount);
        void SetCombination(ECombinationType type);
    }
}