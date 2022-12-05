using Game.Balance.Enums;
using Game.Balance.Interfaces;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Balance
{
    public class BalanceView : MonoBehaviour
    {
        [SerializeField] private EBalanceUnit unit;
        
        [SerializeField] private string pattern;
        [SerializeField] private TMP_Text text;

        private IWallet _wallet;
        
        [Inject]
        private void Construct(IBalanceService service)
        {
            if (service.TryGetWallet(unit, out var wallet))
            {
                _wallet = wallet;
            }
        }

        private void ChangeBalance(int value)
        {
            var result = string.Format(pattern, value);
            text.text = result;
        }

        private void OnEnable()
        {
            _wallet.OnBalanceChanged += ChangeBalance;
            ChangeBalance(_wallet.Balance);
        }

        private void OnDisable()
        {
            _wallet.OnBalanceChanged += ChangeBalance;
        }
    }
}