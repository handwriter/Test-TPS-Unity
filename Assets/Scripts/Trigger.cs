using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Action<bool> OnStateChanged;
    [SerializeField] private LayerMask _layer;

    private void OnTriggerEnter(Collider other)
    {
        if (_layer.Contains(other.gameObject.layer))
        {
            OnStateChanged?.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_layer.Contains(other.gameObject.layer))
        {
            OnStateChanged?.Invoke(false);
        }
    }
}
