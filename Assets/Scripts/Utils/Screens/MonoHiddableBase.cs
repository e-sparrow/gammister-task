using UnityEngine;
using Utils.Screens.Interfaces;

namespace Utils.Screens
{
    public abstract class MonoHiddableBase : MonoBehaviour, IHiddable
    {
        public abstract void Hide();
    }
}