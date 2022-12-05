using System;
using Game.Cards.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Cards
{
    public class CardView : MonoBehaviour, ICardView
    {
        public event Action OnClick = () => { };
        
        [Header("Highlighting")] 
        [SerializeField] private Outline outline;
        
        [Header("References")]
        [SerializeField] private Button button;
        [SerializeField] private Image image;

        public void SetSprite(Sprite sprite)
        {
            image.sprite = sprite;
        }

        public void SetHighlighted(bool isHighlighted)
        {
            outline.enabled = isHighlighted;
        }

        private void Click()
        {
            OnClick.Invoke();
        }

        private void OnEnable()
        {
            button.onClick.AddListener(Click);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(Click);
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}