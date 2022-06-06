using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCharacterAnim : MonoBehaviour
{
    [SerializeField] Animator sittingAnim;
    // Start is called before the first frame update
    void Start()
    {
        sittingAnim.Play("Sitting");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
