using UnityEngine;

public class EnemyDummy : MonoBehaviour, IDamagable
{
    [SerializeField] private float maxHP = 50f;

    private float _currentHP;

    private void Awake()
    {
        _currentHP = maxHP;
    }

    public void TakeDamage(float damage)
    {
        if (damage <= 0f)
            return;

        _currentHP -= damage;

        Debug.Log($"Enemy 피격: {damage} / 남은 HP: {_currentHP}");

        if (_currentHP <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy 사망");
        Destroy(gameObject);
    }
}

