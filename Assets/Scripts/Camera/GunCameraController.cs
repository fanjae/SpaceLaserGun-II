using UnityEngine;

public class GunCameraController : MonoBehaviour
{
    [SerializeField] private Transform gunMuzzle;
    [SerializeField] private Camera gunCamera;

    private void LateUpdate()
    {
        gunCamera.transform.position = gunMuzzle.position;
        gunCamera.transform.rotation = gunMuzzle.rotation;
    }
}