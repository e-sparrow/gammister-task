using System.Threading.Tasks;
using Game.Balance.Enums;
using Game.Balance.Interfaces;
using Game.Bets.Interfaces;
using Utils.Screens.Interfaces;

namespace Game.Bets
{
    public class BetService : IBetService
    {
        public BetService(IBetScreen screen, IScreenService screenService, IBalanceService balanceService)
        {
            _screen = screen;
            
            _screenService = screenService;
            _balanceService = balanceService;
        }

        private readonly IBetScreen _screen;
        
        private readonly IScreenService _screenService;
        private readonly IBalanceService _balanceService;
        
        public async Task<int> GetBet()
        {
            _screenService.ShowScreen(_screen);
            
            _screen.Reset();
            
            var value = await _screen.WaitForBet();
            
            var hasWallet = _balanceService.TryGetWallet(EBalanceUnit.Coins, out var wallet);
            if (hasWallet)
            {
                var hasMoney = wallet.TrySpend(value);
                if (hasMoney)
                {
                    _screenService.Back();
                }
            }

            return value;
        }
    }
}