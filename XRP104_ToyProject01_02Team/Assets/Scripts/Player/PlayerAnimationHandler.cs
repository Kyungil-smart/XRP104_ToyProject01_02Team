using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    private readonly int IsMove = Animator.StringToHash("IsMove");
    private readonly int Fire = Animator.StringToHash("Fire");
    private readonly int Die = Animator.StringToHash("Die");

    private PlayerMovement _movement;
    private Animator _animator;

    private void Awake() => Init();
    private void OnEnable() => SubscribeEvents();
    private void OnDisable() => UnsubscribeEvents();
    
    private void Init()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<PlayerMovement>();
    }

    private void SubscribeEvents()
    {
        _movement.OnMove += OnMove;
    }

    private void UnsubscribeEvents()
    {
        _movement.OnMove -= OnMove;
    }

    private void OnMove(bool isMove) => _animator.SetBool(IsMove, isMove);
    private void OnFire() => _animator.SetTrigger(Fire);
    private void OnDie() => _animator.SetTrigger(Die);
}
