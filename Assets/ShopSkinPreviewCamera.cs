using UnityEngine;

namespace DefaultNamespace
{
    public class ShopSkinPreviewCamera : MonoBehaviour
    {
        public RenderTexture Texture { get; protected set; }

        public static ShopSkinPreviewCamera Instance { get; private set; }    

        private void Awake()
        {
            Instance = this;
        }
    }
}