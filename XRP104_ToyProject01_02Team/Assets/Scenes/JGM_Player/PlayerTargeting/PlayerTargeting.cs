using System.Collections.Generic;
using UnityEngine;

public class PlayerTargeting : MonoBehaviour
{
    [Header("Target Settings")]
    [SerializeField] private float detectionRadius = 5f;
    [SerializeField] private LayerMask obstacleLayer;

    private List<Transform> _enemyList = new List<Transform>();
    private Transform _currentTarget;

    private void Update()
    {
        UpdateTarget();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy"))
            return;

        if (!_enemyList.Contains(other.transform))
        {
            _enemyList.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Enemy"))
            return;

        if (_enemyList.Contains(other.transform))
        {
            _enemyList.Remove(other.transform);
        }
    }

    private void UpdateTarget()
    {
        if (_enemyList.Count == 0)
        {
            _currentTarget = null;
            return;
        }

        Transform closest = GetClosestEnemy();

        if (closest == null)
        {
            _currentTarget = null;
            return;
        }

        if (IsVisible(closest))
        {
            _currentTarget = closest;
        }
        else
        {
            _currentTarget = null;
        }

        if (_currentTarget != null)
        {
            Debug.Log($"현재 타겟: " + _currentTarget.name);
        }
        else
        {
            Debug.Log($"현재 타겟 없음");
        }

    }
    private Transform GetClosestEnemy()
    {
        float minDistance = float.MaxValue;
        Transform closest = null;

        foreach (var enemy in _enemyList)
        {
            if (enemy == null)
                continue;

            float distance = Vector3.Distance(transform.position, enemy.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                closest = enemy;
            }
        }

        return closest;
    }

    private bool IsVisible(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, target.position);

        if (Physics.Raycast(transform.position, direction, out RaycastHit hit, distance))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                return true;
            }
        }

        return false;
    }

    public Transform GetCurrentTarget()
    {
        return _currentTarget;
    }
}
