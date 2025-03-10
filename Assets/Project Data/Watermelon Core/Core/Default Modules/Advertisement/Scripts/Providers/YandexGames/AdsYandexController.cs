using System;
using System.Collections;
using TMPro;
using UnityEngine;
using YG;

namespace Watermelon.Providers.YandexGames
{
    public class AdsYandexController : MonoBehaviour
    {
        [SerializeField] private GameObject _interstitialObject;
        [SerializeField] private TMP_Text _adsStartThroughText;
        [SerializeField] private Initialiser _initialiser;
        
        public static AdsYandexController Instance { get; private set; }
        
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(_interstitialObject);
            Instance = this;
            StartCoroutine(LoadYandexData());
        }

        private IEnumerator LoadYandexData()
        {
            MultiTextUI.lang = YandexGame.lang;
            
            yield return new WaitUntil(() => YandexGame.SDKEnabled);
            YandexGame.InitEnvirData();
            Debug.Log("[AdsYandexController]: Yandex SDK initialized " + YandexGame.EnvironmentData.deviceType);
            
            _initialiser.Init();
        }
        
        public void StartShowInterstitial()
        {
            StartCoroutine(StartShowInterstitialCoroutine());
        }
        
        public IEnumerator StartShowInterstitialCoroutine()
        {
            _interstitialObject.SetActive(true);
            _adsStartThroughText.text = "2";

            yield return new WaitForSeconds(1);
            _adsStartThroughText.text = "1";

            yield return new WaitForSeconds(1);
            _adsStartThroughText.text = "";
            
            _interstitialObject.SetActive(false);
            YandexGame.FullscreenShow();
        }
    }
}