using System;
using FirstPersonMobileTools;
using UnityEngine;

namespace DefaultNamespace
{
    public class MobileJoysticksCanvas : MonoBehaviour
    {
        [SerializeField] private Joystick _moveJoystick;
        [SerializeField] private GameObject _supportBtn;
        private bool _isSlow;
        private bool _isSpawnSupport;
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public bool IsForward()
        {
            return _moveJoystick.Vertical > 0;
        }
        
        public bool IsBackward()
        {
            return _moveJoystick.Vertical < 0;
        }
        
        public bool IsLeft()
        {
            return _moveJoystick.Horizontal < 0;
        }
        
        public bool IsRight()
        {
            return _moveJoystick.Horizontal > 0;
        }

        public bool IsSlow() => _isSlow;

        public bool IsSpawnSupport() => _isSpawnSupport;
        
        public void OnSlowBtnPressed() => _isSlow = true;
        
        public void OnSlowBtnReleased() => _isSlow = false;
        
        public void OnSupportBtnPressed() => _isSpawnSupport = true;
        
        public void OnSupportBtnReleased() => _isSpawnSupport = false;

        public void SendEvent(string eventName)
        {
            switch (eventName)
            {
                case "show_support": _supportBtn.SetActive(true); break;
                case "hide_support": _supportBtn.SetActive(false); break;
            }
        }
    }
}