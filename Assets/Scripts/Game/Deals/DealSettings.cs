using System;
using Game.Deals.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Deals
{
    [Serializable]
    public class DealSettings : IDealSettings
    {
        [field: SerializeField]
        public int CardCount
        {
            get;
            private set;
        }

        [field: SerializeField]
        public int SwitchesCount
        {
            get;
            private set;
        }
    }
}