using UnityEngine;
using Watermelon;

namespace Watermelon
{
    public class CheckHandler : MonoBehaviour
    {
        [ContextMenu(nameof(Check))]
        public void Check()
        {
            
            
            Debug.Log("Check");
            Debug.Log("Check " + Time.timeScale);
        }
    }
}
