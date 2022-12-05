using UnityEngine;

namespace Utils.Screens
{
    public class MonoHiddable : MonoHiddableBase
    {
        [SerializeField] private GameObject target;
        
        public override void Hide()
        {
            target.SetActive(false);
        }
    }
}