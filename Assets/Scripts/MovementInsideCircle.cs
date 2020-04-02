using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInsideCircle : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _radius;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = GetNextPosition();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        if (transform.position == _targetPosition)
            _targetPosition = GetNextPosition();
    }

    private Vector2 GetNextPosition()
    {
        return Random.insideUnitCircle * _radius;
    }
}
