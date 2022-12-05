using System;
using System.Collections.Generic;
using System.Linq;
using Game.Combinations.Enums;
using Game.Deals.Interfaces;
using UnityEngine;

namespace Game.Deals
{
    [CreateAssetMenu(menuName = "Configurations/Deal", fileName = "DealConfiguration")]
    public class DealConfiguration : ScriptableObject, IDealConfiguration
    {
        [SerializeField] private List<CombinationMultiplier> combinationCosts;

        public float GetCombinationMultiplier(ECombinationType type)
        {
            var cost = combinationCosts.FirstOrDefault(value => value.Type == type);

            var result = cost.Multiplier;
            return result;
        }

        [Serializable]
        private struct CombinationMultiplier
        {
            [field: SerializeField]
            public ECombinationType Type
            {
                get;
                private set;
            }

            [field: SerializeField]
            public float Multiplier
            {
                get;
                private set;
            }
        }
    }
}