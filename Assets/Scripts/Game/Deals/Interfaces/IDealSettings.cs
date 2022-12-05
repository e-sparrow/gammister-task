using UnityEngine.UI;

namespace Game.Deals.Interfaces
{
    public interface IDealSettings
    {
        int CardCount
        {
            get;
        }

        int SwitchesCount
        {
            get;
        }
    }
}