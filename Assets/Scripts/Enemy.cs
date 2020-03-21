using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _spawnRadius;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = Random.insideUnitCircle * _spawnRadius;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _movementSpeed * Time.deltaTime);
        if (transform.position == _targetPosition)
            _targetPosition = Random.insideUnitCircle * _spawnRadius;
    }
}
