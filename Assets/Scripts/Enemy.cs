using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _spawnRadius;

    private Vector3 _targetPosition;
    private float _deadDistance;

    public event Action<Enemy> Died; 

    private void Start()
    {
        _targetPosition = Random.insideUnitCircle * _spawnRadius;
        _deadDistance = 0.2f;
    }

    private void Update()
    {
        Move();

        if (CanDie())
        {
            Died?.Invoke(this);
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _movementSpeed * Time.deltaTime);
        if (transform.position == _targetPosition)
            _targetPosition = Random.insideUnitCircle * _spawnRadius;
    }

    private bool CanDie()
    {
        return Vector2.Distance(transform.position, _player.position) < _deadDistance;
    }
}
