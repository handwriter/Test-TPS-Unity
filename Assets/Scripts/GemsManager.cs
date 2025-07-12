using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class GemsManager : MonoBehaviour
    {
        [SerializeField] private int[] _levels;
        [SerializeField] private GameObject _support;
        [SerializeField] private GameObject _gem;
        private int _level;
        private ISaveLoadManager _saveLoadManager;
        private IInputManager _inputManager;
        private DiContainer _container;
        private List<GameObject> _gems = new List<GameObject>();

        [Inject]
        private void Construct(ISaveLoadManager saveLoadManager, IInputManager inputManager, DiContainer container)
        {
            _saveLoadManager = saveLoadManager;
            _inputManager = inputManager;
            _container = container;
        }

        private void Start()
        {
            _saveLoadManager.SetGemsCount(0);
            _saveLoadManager.SetTargetGems(_levels[_level]);
        }

        public void SpawnSupport()
        {
            var obj = Instantiate(_support);
            obj.transform.position = LevelManager.instance.Player.transform.position;
            _saveLoadManager.SetGemsCount(0);
            _level = Mathf.Min(_level + 1, _levels.Length - 1);
            _saveLoadManager.SetTargetGems(_levels[_level]);
        }

        public void MagnetAllGems()
        {
            foreach (var gem in _gems)
            {
                if (gem)
                    gem.transform.DOMove(LevelManager.instance.Player.transform.position, 0.3f);
            }
        }
        
        public void SpawnGem(Vector3 pos)
        {
            var gem = _container.InstantiatePrefab(_gem);
            gem.transform.position = pos;
            _gems.Add(gem);
        }
        
        private void Update()
        {
            var gemsCount = _saveLoadManager.GetGemsCount();
            var targetGemsCount = _saveLoadManager.GetTargetGems();
            if (_inputManager.IsSpawnSupport() && gemsCount >= targetGemsCount)
            {
                SpawnSupport();
            }
        }
    }
}