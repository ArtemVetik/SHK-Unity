using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Coroutine _boost;
    private float _speedBoost;

    private void Start()
    {
        _boost = null;
        _speedBoost = 1f;
    }

    private void Update()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(moveDirection * _speed * _speedBoost * Time.deltaTime);
    }

    public void SpeedBoost(float factor, float duration)
    {
        _speedBoost = factor;
        if (_boost != null)
        {
            StopCoroutine(_boost);
            _boost = null;
        }
        StartCoroutine(SpeedBoostCoroutine(duration));
    }

    private IEnumerator SpeedBoostCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        _speedBoost = 1f;   
    }
}
