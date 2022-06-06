using UnityEngine;

public class ZaxeTrigger : MonoBehaviour
{
    ZAxeObs zaxeObs;

    private void Start()
    {
        zaxeObs = GetComponentInParent<ZAxeObs>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            zaxeObs.MovePermission = true;
        }
    }


}
