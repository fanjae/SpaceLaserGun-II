using UnityEngine;

public class TurretGunShooter : MonoBehaviour
{
    [SerializeField] private GameObject cannonPrefab;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform firePoint;

    [Header("Laser Cooldown")]
    [SerializeField] private float laserCooldown = 5f;

    // 마지막 레이저 발사시간
    private float lastLaserFireTime = -5f;

    // 현재 쿨타임 값
    public float LaserCooldown => laserCooldown;
    public float LastLaserFireTime => lastLaserFireTime;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(cannonPrefab, firePoint.position, firePoint.rotation);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            TryShootLaser();
        }
    }

    // 레이저 발사 시도
    private void TryShootLaser()
    {
        if (!CanShootLaser())
            return;

        Instantiate(laserPrefab, firePoint.position, firePoint.rotation);

        // 시간 갱신
        lastLaserFireTime = Time.time;
    }

    // 레이저 발사 상태 체크
    public bool CanShootLaser()
    {
        return Time.time - lastLaserFireTime >= laserCooldown;
    }

    // 현재 남은 레이저 쿨타임 시간 계산
    public float GetLaserRemainingTime()
    {
        float remainingTime = laserCooldown - (Time.time - lastLaserFireTime);

        // 최소값 제한 (0초 이하로 내려가지 않게)
        return Mathf.Max(remainingTime, 0f); 
    }
}