using UnityEngine;
using Utils.Screens.Interfaces;

namespace Utils.Screens
{
    public abstract class MonoShowableBase : MonoBehaviour, IShowable
    {
        public abstract void Show();
    }
    
    public abstract class MonoShowableBase<TArgument> : MonoBehaviour, IShowable<TArgument>
    {
        public abstract void Show(TArgument argument);
    }
}