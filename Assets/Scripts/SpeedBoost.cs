using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private float _factor;
    [SerializeField] private float _duration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.AddSpeedBoost(_factor, _duration);
            Destroy(gameObject);
        }
    }
}
