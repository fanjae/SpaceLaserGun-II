using UnityEngine;

public class TurretGunAim : MonoBehaviour
{
    [SerializeField] private float pitchSpeed = 30f;
    [SerializeField] private float minPitch = -25f;
    [SerializeField] private float maxPitch = 5f;

    // 포신의 각도
    private float currentAngle;
    private Quaternion baseRotation;

    private void Awake()
    {
        // 포신의 초기 회전 값
        baseRotation = transform.localRotation;

        // 현재 각도 초기화
        currentAngle = 0f;
    }

    private void Update()
    {
        float input = 0f;

        if (Input.GetKey(KeyCode.UpArrow)) input += 1f;
        if (Input.GetKey(KeyCode.DownArrow)) input -= 1f;

        currentAngle += input * pitchSpeed * Time.deltaTime;
        currentAngle = Mathf.Clamp(currentAngle, minPitch, maxPitch);

        // 포신 각도 회전. 처음 각도에서 회전 추가 적용
        transform.localRotation = baseRotation * Quaternion.Euler(currentAngle, 0f, 0f);
    }
}