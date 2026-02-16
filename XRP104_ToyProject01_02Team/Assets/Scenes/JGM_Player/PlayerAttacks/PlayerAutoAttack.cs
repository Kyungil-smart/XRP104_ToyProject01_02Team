using UnityEngine;

[RequireComponent(typeof(PlayerTargeting))]
public class PlayerAutoAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private float coolTime = 0.5f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;

    private PlayerTargeting _targeting;
    private float _lastAttackTime = -999f;
    private bool _isAttacking = false;

    private void Awake()
    {
        _targeting = GetComponent<PlayerTargeting>();

        if (_targeting == null)
        {
            Debug.LogError("PlayerTargeting이 없습니다.");
            enabled = false;
            return;
        }

        if (projectilePrefab == null)
        {
            Debug.LogError("Projectile Prefab이 설정되지 않았습니다.");
            enabled = false;
        }
    }

    private void Update()
    {
        HandleInput();
        TryAttack();
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
            _isAttacking = true;

        if (Input.GetMouseButtonUp(0))
            _isAttacking = false;
    }

    private void TryAttack()
    {
        if (!_isAttacking)
            return;

        if (Time.time < _lastAttackTime + coolTime)
            return;

        Transform target = _targeting.GetCurrentTarget();

        if (target == null)
            return;

        Attack(target);
        _lastAttackTime = Time.time;
    }

    private void Attack(Transform target)
    {
        if (projectilePrefab == null)
            return;

        Vector3 spawnPosition = firePoint != null ? firePoint.position : transform.position;
        Vector3 direction = (target.position - spawnPosition).normalized;

        if (direction.sqrMagnitude < 0.001f)
            return;

        GameObject projectileObj = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

        if (projectileObj == null)
            return;

        Projectile projectile = projectileObj.GetComponent<Projectile>();

        if (projectile == null)
        {
            Debug.LogError("Projectile 컴포넌트가 없습니다.");
            Destroy(projectileObj);
            return;
        }

        projectile.Initialize(direction, damage, gameObject);
    }
}


