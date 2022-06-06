using UnityEngine;

public class ExitPlatformCam : MonoBehaviour
{
    [SerializeField] SwitchCamera switchCamera;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switchCamera.ExitPlatformCam();
        }
    }
}
