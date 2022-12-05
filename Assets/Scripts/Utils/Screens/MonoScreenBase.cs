using UnityEngine;
using Utils.Screens.Interfaces;

namespace Utils.Screens
{
    public abstract class MonoScreenBase : MonoBehaviour, IScreen
    {
        [SerializeField] private MonoShowableBase showable;
        [SerializeField] private MonoHiddableBase hiddable;
        
        public virtual void Show()
        {
            showable.Show();
        }

        public virtual void Hide()
        {
            hiddable.Hide();
        }
    }
    
    public abstract class MonoScreenBase<TArgument> : MonoBehaviour, IScreen<TArgument>
    {
        [SerializeField] private MonoShowableBase showable;
        [SerializeField] private MonoHiddableBase hiddable;
        
        public virtual void Show(TArgument argument)
        {
            showable.Show();
        }

        public virtual void Hide()
        {
            hiddable.Hide();
        }
    }
}