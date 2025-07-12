using System;

namespace DefaultNamespace
{
    public interface IAdsManager
    {
        public void ShowRewardAd(string id);
        public void AddRewardAdListener(Action<string> callback);
        public void RemoveRewardAdListener(Action<string> callback);
        public void ShowInterAd();
    }
}