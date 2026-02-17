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

        // Debug.Log($"플레이어 피격: {damage} / 남은 HP: {_currentHP}");

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

        // TODO: GameManager 구현 후 연결 예정
        // GameManager.Instance.GameOver();
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
