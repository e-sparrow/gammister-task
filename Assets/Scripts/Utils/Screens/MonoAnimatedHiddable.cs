using UnityEngine;
using Utils.Screens.Interfaces;

namespace Utils.Screens
{
    public class MonoAnimatedHiddable : MonoHiddableBase, IHiddable
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string triggerName;

        public override void Hide()
        {
            var trigger = Animator.StringToHash(triggerName);
            animator.SetTrigger(trigger);
        }
    }
}