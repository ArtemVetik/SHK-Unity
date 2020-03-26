using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class EndOfGameTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _gameOver;

    private List<Enemy> _enemies;

    private void OnEnable()
    {
        _enemies = GetComponentsInChildren<Enemy>().ToList();
        foreach (var enemy in _enemies)
        {
            enemy.Died += OnEnemyDied;
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died -= OnEnemyDied;
        }
    }

    private void OnEnemyDied(Enemy diedEnemy)
    {
        diedEnemy.Died -= OnEnemyDied;
        _enemies.Remove(diedEnemy);

        if (_enemies.Count <= 0)
            _gameOver?.Invoke();
    }
}
