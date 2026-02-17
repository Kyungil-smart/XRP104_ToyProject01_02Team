using UnityEngine;

public class EndPortal : MonoBehaviour
{
    [SerializeField] private LayerMask _interactionLayer;

    private void OnTriggerEnter(Collider other) => Interaction(other);

    private void Interaction(Collider other)
    {
        if (((1 << other.gameObject.layer) & _interactionLayer.value) == 0) return;
        if (StageInfo.Instance.HasRemainingEnemies) return;

        GameManager.Instance.StageClear();
    }
}
