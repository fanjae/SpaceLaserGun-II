using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [Header("Move Settings")]
    [SerializeField] private float moveSpeed = 4f;

    private Transform target;
    public void Init(Transform targetPoint)
    {
        target = targetPoint;
    }

    private void Update() 
    {
        if (target == null)
            return;

        // 현재 목표 위치 저장
        Vector3 destination = target.position;

        // 현재 위치에서 목표 위치 까지 이동
        transform.position = Vector3.MoveTowards(transform.position,destination,moveSpeed * Time.deltaTime);
    }

}