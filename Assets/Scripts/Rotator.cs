using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
    [SerializeField] GameObject Cylinder1;
    [SerializeField] GameObject Cylinder2;
    public bool RotateBool = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayRotator());
    }

    // Update is called once per frame
    void Update()
    {
        Cylinder1.transform.Rotate(0, 0, 40.0f*Time.deltaTime, Space.Self);
        if (RotateBool)
        {
            Cylinder2.transform.Rotate(0, 0, 40.0f * Time.deltaTime, Space.Self);
        }
    }

    IEnumerator DelayRotator()
    {
        yield return new WaitForSeconds(1.0f);
        RotateBool = true;
    }
}
