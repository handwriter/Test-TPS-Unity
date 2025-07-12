using System;
using FirstPersonMobileTools;
using UnityEngine;

namespace DefaultNamespace
{
    public class MobileJoysticksCanvas : MonoBehaviour
    {
        [SerializeField] private Joystick _moveJoystick;
        [SerializeField] private GameObject _supportBtn;
        [SerializeField] private GameObject _adBtn;
        private bool _isSlow;
        private bool _isSpawnSupport;
        private bool _isWatchAd;
        private bool _isShoot;
        private void Start() => DontDestroyOnLoad(gameObject);

        public bool IsForward() => _moveJoystick.Vertical > 0;
        
        public bool IsBackward() => _moveJoystick.Vertical < 0;
        
        public bool IsLeft() => _moveJoystick.Horizontal < 0;

        public bool IsRight() => _moveJoystick.Horizontal > 0;

        public bool IsSlow() => _isSlow;

        public bool IsSpawnSupport() => _isSpawnSupport;

        public bool IsShoot() => _isShoot;

        public bool IsWatchAd()
        {
            bool watchAd = _isWatchAd;
            _isWatchAd = false;
            return watchAd;
        }
        
        public void OnSlowBtnPressed() => _isSlow = true;
        
        public void OnSlowBtnReleased() => _isSlow = false;
        
        public void OnSupportBtnPressed() => _isSpawnSupport = true;
        
        public void OnSupportBtnReleased() => _isSpawnSupport = false;

        public void OnAdBtnPressed() => _isWatchAd = true;
        
        public void OnAdBtnReleased() => _isWatchAd = false;
        
        public void OnShootBtnPressed() => _isShoot = true;
        
        public void OnShootBtnReleased() => _isShoot = false;
        
        public void SendEvent(string eventName)
        {
            switch (eventName)
            {
                case "show_support": _supportBtn.SetActive(true); break;
                case "hide_support": _supportBtn.SetActive(false); break;
                case "show_survive_ad": _adBtn.SetActive(true); break;
                case "hide_survive_ad": _adBtn.SetActive(false); break;
            }
        }
    }
}