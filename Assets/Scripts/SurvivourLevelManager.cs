using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Zenject;
using Random = System.Random;

public class SurvivourLevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private int[] _levels;
    [SerializeField] private GameObject[] _items;
    private Transform[] _points;
    private int _level;
    private int _deathsCount;
    private DiContainer _container;
    private GemsManager _gemsManager;

    [Inject]
    private void Construct(DiContainer container, GemsManager gemsManager)
    {
        _container = container;
        _gemsManager = gemsManager;
    }
    
    private void Start()
    {
        SpawnLevelEnemies();
    }

    private void SpawnLevelEnemies()
    {
        _deathsCount = 0;
        _points = Utils.Shuffle(_spawnPoints);
        for (int i = 0;i < _levels[_level];i++)
        {
            var obj = _container.InstantiatePrefab(_enemyPrefab);
            obj.transform.position = ((Transform)_points.GetValue(i)).position;
            obj.GetComponent<Combat>().OnDead += OnDead;
        }
        _level = Mathf.Min(_level + 1, _levels.Length - 1);
    }

    

    private void SpawnRandomItem(Vector3 position)
    {
        var itemPref = _items[UnityEngine.Random.Range(0, _items.Length)];
        var item = _container.InstantiatePrefab(itemPref);
        item.transform.position = position;
    }
    
    private void OnDead(Vector3 enemyPos)
    {
        _gemsManager.SpawnGem(enemyPos);
        if (UnityEngine.Random.Range(0, 100) > 50)
        {
            SpawnRandomItem(enemyPos);
        }
        _deathsCount++;
        if (_deathsCount == _levels[_level - 1])
        {
            SpawnLevelEnemies();
        }
    }
}
