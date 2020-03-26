using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _speedBoost;

    private void Start()
    {
        _speedBoost = 1f;
    }

    private void Update()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(moveDirection * _speed * _speedBoost * Time.deltaTime);
    }

    public void AddSpeedBoost(float factor, float duration)
    {
        StartCoroutine(AddSpeedBoostCoroutine(factor, duration));
    }

    private IEnumerator AddSpeedBoostCoroutine(float factor, float duration)
    {
        _speedBoost += factor;
        yield return new WaitForSeconds(duration);
        _speedBoost -= factor;   
    }
}
