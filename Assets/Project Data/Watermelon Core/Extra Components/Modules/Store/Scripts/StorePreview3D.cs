using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Watermelon.Store
{
    public class StorePreview3D : MonoBehaviour
    {
        [SerializeField] Camera previewCamera;

        [SerializeField] Transform prefabParent;
        [SerializeField] Vector3 spawnPosition;
        [SerializeField] private GameObject defaultPrefab;
        [SerializeField] private Material defaultMaterial;

        public Transform PrefabParent => prefabParent;
        public RenderTexture Texture { get; protected set; }
        public GameObject Prefab { get; protected set; }

        public virtual void Init()
        {
            transform.position = spawnPosition;
            Texture = new RenderTexture(previewCamera.scaledPixelWidth, previewCamera.scaledPixelHeight, 16);

            SpawnProduct(defaultPrefab);
            previewCamera.targetTexture = Texture;
        }

        public virtual void SpawnProduct(ProductData data)
        {
            ChangeSkin(data.Skin);
        }

        private void ChangeSkin(Texture skin)
        {
            defaultMaterial.SetTexture("_MainTex", skin);
        }

        private void SpawnProduct(GameObject data)
        {
            Prefab = Instantiate(data, prefabParent, true);

            Prefab.transform.localPosition = Vector3.zero;
            Prefab.transform.localRotation = Quaternion.identity;
            Prefab.transform.localScale = Vector3.one;
        }
    }
}