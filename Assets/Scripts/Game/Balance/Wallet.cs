using System;
using Game.Balance.Interfaces;

namespace Game.Balance
{
    public class Wallet : IWallet
    {
        public Wallet(int balance = 0)
        {
            _balance = balance;
        }
        
        public event Action<int> OnBalanceChanged = _ => { };

        private int _balance;
        
        public void Add(int value)
        {
            Balance += value;
        }

        public bool TrySpend(int value)
        {
            var result = Balance >= value;
            if (result)
            {
                Balance -= value;
            }

            return result;
        }

        public int Balance
        {
            get => _balance;
            private set
            {
                _balance = value;
                OnBalanceChanged.Invoke(_balance);
            }
        }
    }
}