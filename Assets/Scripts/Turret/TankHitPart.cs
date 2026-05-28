using UnityEngine;

public class HitPart : MonoBehaviour
{
    [SerializeField] private LifeUI tankLife;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Planet")) return;
        tankLife.Damage(); // 탱크 데미지 입히기

        Destroy(other.gameObject); // 부딪힌 행성은 삭제
    }
}