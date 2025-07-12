using System;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class Magnet : MonoBehaviour
    {
        [SerializeField] private Trigger _trigger;
        private GemsManager _gemsManager;
        
        [Inject]
        private void Construct(GemsManager gemsManager)
        {
            _gemsManager = gemsManager;
        }
        
        private void Awake()
        {
            _trigger.OnStateChanged += OnStateChanged;
        }

        private void OnStateChanged(bool state)
        {
            if (state)
            {
                _gemsManager.MagnetAllGems();
                Destroy(gameObject);
            }
        }
    }
}