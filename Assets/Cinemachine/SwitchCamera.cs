using Cinemachine;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vcam1;   // 3rd person camera
    [SerializeField] CinemachineVirtualCamera vcam2;   // menu camera
    [SerializeField] CinemachineVirtualCamera vcam3;   // finish camera
    [SerializeField] CinemachineVirtualCamera vcam4;   // platform camera

    private bool overWorldCamera = true;

    public void SwitchPriority()
    {
        if (overWorldCamera)
        {
            vcam1.Priority = 1;
            vcam2.Priority = 0;
        }
        else
        {
            vcam1.Priority = 0;
            vcam2.Priority = 1;
        }
        overWorldCamera = !overWorldCamera;
    }

    public void SwitchEndCamera()
    {
        vcam3.Priority = 10;
    }

    public void SwitchPlatformCam()
    {
        vcam4.Priority = 15;
    }
    public void ExitPlatformCam()
    {
        vcam4.Priority = -15;
    }
}
