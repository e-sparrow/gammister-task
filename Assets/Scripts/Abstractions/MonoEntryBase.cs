using Abstractions.Interfaces;
using UnityEngine;

namespace Abstractions
{
    public abstract class MonoEntryBase : MonoBehaviour, IEntry
    {
        protected abstract void InstallInternal();
        
        public void Install()
        {
            InstallInternal();
        }

        [field: SerializeField]
        public bool IsEnabled
        {
            get;
            private set;
        }
    }
}