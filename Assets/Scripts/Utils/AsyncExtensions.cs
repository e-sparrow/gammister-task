using System.Threading.Tasks;
using UnityEngine.UI;

namespace Utils
{
    public static class AsyncExtensions
    {
        public static async Task WaitForClick(this Button button)
        {
            var source = new TaskCompletionSource<bool>();
            button.onClick.AddListener(Click);
                
            await source.Task;
            
            void Click()
            {
                button.onClick.RemoveListener(Click);
                source.SetResult(true);
            }
        }
    }
}