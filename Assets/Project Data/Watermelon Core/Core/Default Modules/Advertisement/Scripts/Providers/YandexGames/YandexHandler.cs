using UnityEngine;
using Watermelon;
using Watermelon.Providers.YandexGames;
using YG;

namespace Project_Data.Watermelon_Core.Core.Default_Modules.Advertisement.Scripts.Providers.YandexGames
{
    public class YandexHandler : AdvertisingHandler
    {
        private RewardedVideoCallback _rewardedVideoCallback;
        private bool _isInterstitialStarted;
        
        public YandexHandler(AdvertisingModules moduleType) : base(moduleType) {}

        public override void Init(AdsData adsSettings)
        {
            this.adsSettings = adsSettings;

            isInitialized = true;
            YandexGame.RewardVideoEvent = RewardedYandexVideoCallback;

            if (adsSettings.SystemLogs)
                Debug.Log("[AdsManager]: Module " + ModuleType.ToString() + " has initialized!");

            if (AdsManager.OnAdsModuleInitializedEvent != null)
                AdsManager.OnAdsModuleInitializedEvent.Invoke(ModuleType);
        }

        public override void SetGDPR(bool state)
        {
            
        }

        public override void ShowBanner()
        {
            
        }

        public override void HideBanner()
        {
            
        }

        public override void DestroyBanner()
        {
            
        }

        public override void RequestInterstitial()
        {
            if (AdsManager.OnInterstitialLoadedEvent != null)
                AdsManager.OnInterstitialLoadedEvent.Invoke();
        }

        public override void ShowInterstitial(InterstitialCallback callback)
        {
            if (_isInterstitialStarted) return;
            _isInterstitialStarted = true;
            YandexGame.CloseFullAdEvent = 
                () =>
                {
                    _isInterstitialStarted = false;
                    callback.Invoke(true);
                    ViewingAdsYG.Instance.Pause(false);
                }; 
            AdsYandexController.Instance.StartShowInterstitial();
        }

        public override bool IsInterstitialLoaded()
        {
            return YandexGame.timerShowAd >= 60;
        }

        public override void RequestRewardedVideo()
        {
            
        }

        public override void ShowRewardedVideo(RewardedVideoCallback callback)
        {
            _rewardedVideoCallback = callback;
            Debug.Log("StartVidoe");
            YandexGame.RewVideoShow(0);
        }
        
        public void RewardedYandexVideoCallback(int id)
        {
            _rewardedVideoCallback.Invoke(true);
        }

        public override bool IsRewardedVideoLoaded()
        {
            return true;
        }
    }
}