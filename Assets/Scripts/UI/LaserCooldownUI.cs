using TMPro;
using UnityEngine;
public class LaserCooldownUI : MonoBehaviour
{
    [SerializeField] private TurretGunShooter gunShooter;
    [SerializeField] private TMP_Text laserCooldownText;

    private void Update()
    {
        if (gunShooter == null || laserCooldownText == null)
            return;

        if (gunShooter.CanShootLaser())
        {
            laserCooldownText.text = "Laser : Ready";
        }
        else
        {
            // 레이저 쿨타임에 대한 남은 시간을 가져오되, 소수점 1자리까지만 표기해준다.
            laserCooldownText.text = "Laser : " + gunShooter.GetLaserRemainingTime().ToString("F1");
        }
    }
}