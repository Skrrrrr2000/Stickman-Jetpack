using System.Collections;
using UnityEngine;

public class UpDownObsDelay : MonoBehaviour
{
    [SerializeField] Animator UpdownAnimator;
    [SerializeField] float DelayValue;
    void Start()
    {
        StartCoroutine(UpDownAnimDelay());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator UpDownAnimDelay()
    {
        yield return new WaitForSeconds(DelayValue);
        UpdownAnimator.Play("UpDownAnim");

    }
}
