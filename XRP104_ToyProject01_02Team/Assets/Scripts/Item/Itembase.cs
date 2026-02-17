using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Itembase : MonoBehaviour
{
    [SerializeField] private Vector2 _randForceXZ;
    [SerializeField] private float _ForceY;
    protected Rigidbody _rigidbody;

    protected virtual void Awake() => Init();

    protected virtual void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Drop()
    {
        float x = Random.Range(0, _randForceXZ.x);
        float z = Random.Range(0, _randForceXZ.y);
        
        _rigidbody.AddForce(new Vector3(x, _ForceY, z));
    }
}
