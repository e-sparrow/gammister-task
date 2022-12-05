using System;
using System.Threading.Tasks;
using Game.Combinations.Enums;
using Game.Deals.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Utils.Screens;

namespace Game.Deals
{
    public class DealScreen : MonoScreenBase, IDealScreen
    {
        [Header("Combinations")] 
        [SerializeField] private string combinationTextPattern;
        [SerializeField] private string noCombinationsText;
        [SerializeField] private TMP_Text combinationText;
        
        [Header("Switches")] 
        [SerializeField] private string switchTextPattern;
        [SerializeField] private TMP_Text switchText;
        
        [Header("Applying")]
        [SerializeField] private Button applyButton;

        [Header("Next")]
        [SerializeField] private Button nextButton;
        
        public void Reset()
        {
            SetSwitches(0);

            combinationText.text = string.Empty;
            nextButton.gameObject.SetActive(false);
        }

        public async Task WaitForApply()
        {
            await applyButton.WaitForClick();
        }

        public async Task WaitForNext()
        {
            nextButton.gameObject.SetActive(true);
            applyButton.gameObject.SetActive(false);
            
            await nextButton.WaitForClick();
            
            nextButton.gameObject.SetActive(false);
            applyButton.gameObject.SetActive(true);
        }

        public void SetSwitches(int amount)
        {
            if (amount > 0)
            {
                switchText.text = string.Format(switchTextPattern, amount);
            }
            else
            {
                switchText.text = string.Empty;
            }
        }

        public void SetCombination(ECombinationType type)
        {
            if (type == ECombinationType.None)
            {
                combinationText.text = noCombinationsText;
            }
            else
            {
                var value = string.Format(combinationTextPattern, type.ToString());
                combinationText.text = value;
            }
        }
    }
}