// MiniCannon.cs
using UnityEngine;

public class MiniCannon : MonoBehaviour
{
    [SerializeField] private float speed = 25f;
    [SerializeField] private float lifeTime = 6f;

    private void Start()
    {
        // 발사 6초 뒤 시점에서 캐논볼 오브젝트 제거
        Destroy(gameObject, lifeTime);
    }

    private void FixedUpdate()
    {
        // 캐논볼은 앞 방향으로 계속 이동한다.
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("충돌 감지: " + other.name);

        // 행성과 충돌처리
        if (other.CompareTag("Planet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}