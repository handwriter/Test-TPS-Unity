using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Zenject;

public class Gem : MonoBehaviour
{
    [SerializeField] private Trigger _trigger;
    private ISaveLoadManager _saveLoadManager;
    
    [Inject]
    private void Costruct(ISaveLoadManager saveLoadManager)
    {
        _saveLoadManager = saveLoadManager;
    }
    
    private void Awake()
    {
        _trigger.OnStateChanged += OnStateChanged;
    }

    private void OnStateChanged(bool state)
    {
        if (state)
        {
            _saveLoadManager.IncrementGems(1);
            Destroy(gameObject);
        }
    }
}
