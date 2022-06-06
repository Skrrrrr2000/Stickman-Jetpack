using UnityEngine;

public class SwitchPlatformTrigger : MonoBehaviour
{
    [SerializeField] SwitchCamera switchCamera;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switchCamera.SwitchPlatformCam();
        }
    }
}
