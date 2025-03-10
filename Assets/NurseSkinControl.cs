using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class NurseSkinControl : MonoBehaviour
{
    [SerializeField] private Material _nurseMaterial;
    [SerializeField] private Texture[] _skins;

    private void Start()
    {
        _nurseMaterial.SetTexture("_MainTex", _skins[Random.Range(0, _skins.Length)]);
    }
}