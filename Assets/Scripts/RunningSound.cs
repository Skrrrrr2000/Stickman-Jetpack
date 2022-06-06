using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningSound : MonoBehaviour
{
    [SerializeField] AudioSource footStep;
    [SerializeField] AudioClip FootStepClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Step()
    {
        footStep.PlayOneShot(FootStepClip);
    }
}
