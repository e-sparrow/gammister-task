using System;

namespace Game.Balance.Interfaces
{
    public interface IWallet
    {
        event Action<int> OnBalanceChanged;

        void Add(int value);
        bool TrySpend(int value);

        int Balance
        {
            get;
        }
    }
}