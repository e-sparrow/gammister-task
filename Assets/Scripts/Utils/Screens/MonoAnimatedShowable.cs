using UnityEngine;
using Utils.Screens.Interfaces;

namespace Utils.Screens
{
    public class MonoAnimatedShowable : MonoShowableBase, IShowable
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string triggerName;
        
        public override void Show()
        {
            var trigger = Animator.StringToHash(triggerName);
            animator.SetTrigger(trigger);
        }
    }
}