using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [Header("Health Settings")]
    [SerializeField] private float maxHP = 10f;

    [SerializeField] private float _currentHP;
    private bool _isDead = false;
    private PlayerMovement _movement;

    public event Action OnDie;

    private void Awake()
    {
        _currentHP = maxHP;
        _movement = GetComponent<PlayerMovement>();
    }

    public void TakeDamage(float damage)
    {
        if (_isDead)
            return;

        if (damage <= 0f)
            return;

        _currentHP -= damage;

        if (_currentHP <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        if (_isDead)
            return;

        _isDead = true;

        Debug.Log("플레이어 사망");

        if (_movement != null)
        {
            _movement.enabled = false;
        }

        OnDie?.Invoke();
        GameManager.Instance.GameOver();
    }

    public float GetCurrentHP()
    {
        return _currentHP;
    }

    public bool IsDead()
    {
        return _isDead;
    }
}
