using UnityEngine;
using Utils.Screens.Interfaces;

namespace Utils.Screens
{
    public class MonoShowable : MonoShowableBase, IShowable
    {
        [SerializeField] private GameObject target;
        
        public override void Show()
        {
            target.SetActive(true);
        }
    }
}