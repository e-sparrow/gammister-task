using System.Collections.Generic;
using Game.Balance.Enums;
using Game.Balance.Interfaces;

namespace Game.Balance
{
    public class BalanceService : IBalanceService
    {
        public BalanceService(IDictionary<EBalanceUnit, IWallet> wallets)
        {
            _wallets = wallets;
        }
        
        private readonly IDictionary<EBalanceUnit, IWallet> _wallets;

        public bool TryGetWallet(EBalanceUnit unit, out IWallet wallet)
        {
            wallet = null;
            
            var result = _wallets.ContainsKey(unit);
            if (result)
            {
                wallet = _wallets[unit];
            }

            return result;
        }
    }
}