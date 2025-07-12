using UnityEngine;
using Random = System.Random;

public class Heart : MonoBehaviour
{
    [SerializeField] private Trigger _trigger;
    [SerializeField] private Vector2 _hpBoundaries;

    private void Awake()
    {
        _trigger.OnStateChanged += OnStateChanged;
    }

    private void OnStateChanged(bool state)
    {
        if (state)
        {
            var value = UnityEngine.Random.Range(_hpBoundaries.x, _hpBoundaries.y);
            LevelManager.instance.Player.Combat.Heal((int)value);
            Destroy(gameObject);
        }
    }
}