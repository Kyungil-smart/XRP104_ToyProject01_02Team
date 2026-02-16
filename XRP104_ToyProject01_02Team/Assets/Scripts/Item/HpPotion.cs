using UnityEngine;

public class HpPotion : MonoBehaviour
{
    [SerializeField] [Range(0, 100)] private int healValue = 10;

    private void OnTriggerEnter(Collider other)
    {
        // 충돌 대상의 태그가 "Player" 라면
        if (other.CompareTag("Player"))
        {
            // 충돌체에게서 PlayerController를 얻어온다
            PlayerController playerController = other.GetComponent<PlayerController>();
            
            // playerController에 접근해 Heal 함수를 호출한다
            playerController.Heal(healValue);
            
            // 자신을 파괴한다
            Destroy(gameObject);
        }
    }
}
