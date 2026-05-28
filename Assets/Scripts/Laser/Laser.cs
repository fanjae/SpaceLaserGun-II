// Laser.cs
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float speed = 60f;
    [SerializeField] private float lifeTime = 10f;

    private void Start()
    {
        // 발사 6초 뒤 시점에서 레이저 오브젝트 제거
        Destroy(gameObject, lifeTime);
    }

    private void FixedUpdate()
    {
        // 레이저는 앞 방향으로 계속 이동한다.
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("충돌 감지: " + other.name);

        // 행성과 충돌처리
        if (other.CompareTag("Planet"))
        {
            Destroy(other.gameObject);
        }
    }
}