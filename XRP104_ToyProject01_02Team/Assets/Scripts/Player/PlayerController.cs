using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _defaultHealth = 100f;
    [field: SerializeField] public float CurrentHealth { get; private set; }

    private void Awake() => Init();

    private void Init()
    {
        CurrentHealth = _defaultHealth;
    }

    public void Heal(float value)
    {
        CurrentHealth += value;
    }
}
