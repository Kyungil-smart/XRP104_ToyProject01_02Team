using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Move Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;

    private Rigidbody _rigidbody;

    private Vector3 _inputDirection;
    private Vector3 _moveDirection;

    private bool _prevIsMoving = false;
    public bool IsMoving => _moveDirection != Vector3.zero;

    public event Action<bool> OnMove;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody가 없습니다.");
            enabled = false;
        }
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        _inputDirection = new Vector3(horizontal, 0f, vertical);

        if (_inputDirection.sqrMagnitude > 1f)
        {
            _inputDirection.Normalize();
        }

        _moveDirection = _inputDirection;
    }

    private void FixedUpdate()
    {
        if (_rigidbody == null)
            return;
        
        
        
        Move();
        Rotate();
    }

    private void Move()
    {
        Vector3 velocity = new Vector3(
            _moveDirection.x * moveSpeed,
            _rigidbody.linearVelocity.y,
            _moveDirection.z * moveSpeed
        );

        _rigidbody.linearVelocity = velocity;

        if (_prevIsMoving != IsMoving) OnMove?.Invoke(IsMoving);
        
        _prevIsMoving = IsMoving;
    }

    private void Rotate()
    {
        if (_moveDirection.sqrMagnitude < 0.01f)
            return;

        Quaternion targetRotation = Quaternion.LookRotation(_moveDirection);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.fixedDeltaTime
        );
    }
}
