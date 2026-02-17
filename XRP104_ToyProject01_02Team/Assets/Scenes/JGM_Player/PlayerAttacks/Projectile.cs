using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Projectile : MonoBehaviour
{
    [Header("Projectile Settings")] 
    [SerializeField] private LayerMask _attackTargetLayer;
    [SerializeField] private float speed = 15f;
    [SerializeField] private float lifeTime = 3f;

    private Rigidbody _rigidbody;
    private float _damage;
    private GameObject _owner;
    private bool _initialized = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody가 없습니다.");
            enabled = false;
            return;
        }

        _rigidbody.useGravity = false;
    }

    public void Initialize(Vector3 direction, float damage, GameObject owner)
    {
        if (direction.sqrMagnitude < 0.0001f)
        {
            Destroy(gameObject);
            return;
        }

        _owner = owner;
        _damage = damage;
        _initialized = true;

        Collider[] ownerColliders = owner.GetComponentsInChildren<Collider>();
        Collider myCollider = GetComponent<Collider>();

        if (myCollider != null)
        {
            foreach (var col in ownerColliders)
            {
                if (col != null)
                    Physics.IgnoreCollision(myCollider, col);
            }
        }

        _rigidbody.linearVelocity = direction * speed;

        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_initialized)
            return;

        // if (_owner != null && other.transform.root.gameObject == _owner) return;

        if (((1 << other.gameObject.layer) & _attackTargetLayer.value) == 0) return;
        
        Debug.Log(other.gameObject.name);
        
        IDamagable damageable = other.transform.GetComponent<IDamagable>();

        if (damageable != null)
        {
            damageable.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}

