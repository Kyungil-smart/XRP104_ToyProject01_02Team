using UnityEngine;

public class PlayerDamageTest : MonoBehaviour
{
    private PlayerHealth _health;

    private void Awake()
    {
        _health = GetComponent<PlayerHealth>();

        if (_health == null)
        {
            Debug.LogError("PlayerHealth가 없습니다.");
            enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _health.TakeDamage(15f);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log($"현재 HP: {_health.GetCurrentHP()}");
        }
    }
}