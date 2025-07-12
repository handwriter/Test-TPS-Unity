using System;
using GamePush;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GameObject _gameManager;
        private DiContainer _container;
        
        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
        }
        
        private void Start()
        {
            if (GP_Init.isReady)
            {
                GP_InitOnOnReady();
            }
            else
            {
                GP_Init.OnReady += GP_InitOnOnReady;
            }
        }

        private void GP_InitOnOnReady()
        {
            _container.InstantiatePrefab(_gameManager);
        }
    }
}