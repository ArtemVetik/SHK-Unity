using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class EndOfGameTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent OnEndGameEvent;

    private List<Enemy> _enemies;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>().ToList();
        foreach (var enemy in _enemies)
        {
            enemy.OnDie += OnEnemyDied;
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.OnDie -= OnEnemyDied;
        }
    }

    private void OnEnemyDied(Enemy diedEnemy)
    {
        diedEnemy.OnDie -= OnEnemyDied;
        _enemies.Remove(diedEnemy);

        if (_enemies.Count <= 0)
            OnEndGameEvent?.Invoke();
    }
}
