using Abstractions.Interfaces;
using UnityEngine;

namespace Abstractions
{
    public abstract class ScriptableEntryBase : ScriptableObject, IEntry
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