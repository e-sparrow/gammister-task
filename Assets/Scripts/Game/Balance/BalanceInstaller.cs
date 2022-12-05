using System;
using System.Collections.Generic;
using System.Linq;
using Game.Balance.Enums;
using Game.Balance.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Balance
{
    [CreateAssetMenu(menuName = "Installers/Balance", fileName = "BalanceInstaller")]
    public class BalanceInstaller : ScriptableObjectInstaller<BalanceInstaller>
    {
        [SerializeField] private List<BalanceInfo> balances;

        public override void InstallBindings()
        {
            var wallets = balances
                .ToDictionary(value => value.Unit, value => new Wallet(value.StartValue) as IWallet) 
                as IDictionary<EBalanceUnit, IWallet>;
            
            Container
                .BindInterfacesTo<BalanceService>()
                .AsSingle()
                .WithArguments(wallets);
        }

        [Serializable]
        private struct BalanceInfo
        {
            [field: SerializeField]
            public EBalanceUnit Unit
            {
                get;
                private set;
            }

            [field: SerializeField]
            public int StartValue
            {
                get;
                private set;
            }
        }
    }
}