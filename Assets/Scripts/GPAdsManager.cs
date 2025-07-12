using System;
using GamePush;
using UnityEngine;

namespace DefaultNamespace
{
    public class GPAdsManager : IAdsManager
    {
        private Action<string> _onRewardedAd;
        private bool _isReady;
        
        public GPAdsManager()
        {
            GP_Init.OnReady += OnPluginReady;
            GP_Ads.OnRewardedReward += OnRewardedAd;
        }

        private void OnRewardedAd(string id) => _onRewardedAd?.Invoke(id);

        private void OnPluginReady()
        {
            _isReady = true;
            Debug.Log("[AdsManager] GP Ready");
        }

        public void ShowRewardAd(string id) => GP_Ads.ShowRewarded(id);

        public void AddRewardAdListener(Action<string> callback) => _onRewardedAd += callback;

        public void RemoveRewardAdListener(Action<string> callback) => _onRewardedAd -= callback;
        public void ShowInterAd() => GP_Ads.ShowFullscreen();

    }
}