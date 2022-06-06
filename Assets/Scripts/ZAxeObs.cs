using UnityEngine;

public class ZAxeObs : MonoBehaviour
{
    public bool MovePermission = false;
    private float speed = 15.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (MovePermission)
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * speed);
        }
    }
}
