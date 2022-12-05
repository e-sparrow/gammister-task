using System;
using System.Threading.Tasks;
using Game.Bets.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Utils.Screens;

namespace Game.Bets
{
    public class BetScreen : MonoScreenBase, IBetScreen
    {
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private Button betButton;
        

        public async Task<int> WaitForBet()
        {
            await betButton.WaitForClick();
            
            var value = int.Parse(inputField.text);
            return value;
        }

        public void Reset()
        {
            inputField.text = string.Empty;
        }
    }
}