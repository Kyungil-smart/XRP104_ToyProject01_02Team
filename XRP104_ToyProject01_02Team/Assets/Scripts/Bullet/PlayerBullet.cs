using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float _destroyDelay;
    private Rigidbody _rigidbody;
    private LayerMask _layerMask;

    private float _speed;
    private float _power;
    private Transform _muzzle;

    private void Awake() => Init();
    private void OnTriggerEnter(Collider other) => TrySendDamage(other);

    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetDate(float speed, float power, Transform muzzle, LayerMask layerMask)
    {
        _speed = speed;
        _power = power;
        _muzzle = muzzle;
        _layerMask = layerMask;
    }

    public void Shot()
    {
        transform.position = _muzzle.position;
        transform.rotation = _muzzle.rotation;
        _rigidbody.linearVelocity = _muzzle.forward * _speed;
        Destroy(gameObject, _destroyDelay);        
    }

    private bool TrySendDamage(Collider other)
    {
        if(((1 << other.gameObject.layer) & _layerMask.value) == 0) return false;
        
        IDamagable damagable = other.GetComponent<IDamagable>();
        if(damagable == null) return false;
        
        damagable.TakeDamage(_power);
        Destroy(gameObject);
        return true;
    }
}
