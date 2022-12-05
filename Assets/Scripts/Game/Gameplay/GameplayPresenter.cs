using Game.Balance.Enums;
using Game.Balance.Interfaces;
using Game.Bets.Interfaces;
using Game.Deals.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
    public class GameplayPresenter : IInitializable
    {
        public GameplayPresenter
        (
            IBetService betService,
            IDealService dealService,
            IBalanceService balanceService
        )
        {
            _betService = betService;
            _dealService = dealService;
            _balanceService = balanceService;
        }

        private readonly IBetService _betService;
        private readonly IDealService _dealService;
        private readonly IBalanceService _balanceService;
        
        public async void Initialize()
        {
            while (Application.isPlaying)
            {
                var bet = 0;
                
                do
                {
                    bet = await _betService.GetBet();
                } 
                while (bet <= 0);
                
                var prize = await _dealService.Deal(bet);
                
                var hasWallet = _balanceService.TryGetWallet(EBalanceUnit.Coins, out var wallet);
                if (hasWallet)
                {
                    var value = (int) (bet * prize.Multiplier);
                    wallet.Add(value);
                }
            }
        }
    }
}