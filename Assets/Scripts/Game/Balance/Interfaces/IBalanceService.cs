using Game.Balance.Enums;

namespace Game.Balance.Interfaces
{
    public interface IBalanceService
    {
        bool TryGetWallet(EBalanceUnit unit, out IWallet wallet);
    }
}