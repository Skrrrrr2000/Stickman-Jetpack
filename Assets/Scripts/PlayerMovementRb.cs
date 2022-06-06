using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovementRb : MonoBehaviour
{   
    Rigidbody rb;

    bool engineOn;

    [SerializeField] private float jumpForce;
    public float playerSpeed;


    [SerializeField] public Animator anim;

    [SerializeField] GameObject groundCheck;
    [SerializeField] LayerMask layer;

    [SerializeField] ParticleSystem particleEffect1;
    [SerializeField] ParticleSystem particleEffect2;
    [SerializeField] ParticleSystem particleEffect3;
    [SerializeField] ParticleSystem particleEffect4;
    [SerializeField] ParticleSystem particleEffect5;

    public AudioSource JetpackEngineSound;

    public bool isFinish = false;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 0;
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, 1 * playerSpeed);


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !isFinish && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            //rb.AddForce(Vector3.up * jumpForce * 3, ForceMode.Impulse);
            particleEffect1.Play();
            particleEffect2.Play();
            particleEffect3.Play();
            particleEffect4.Play();
            particleEffect5.Play();

            engineOn = true;


            JetpackEngineSound.volume = 0.2f;
            JetpackEngineSound.Play();
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && !isFinish)
        {
            particleEffect1.Stop();
            particleEffect2.Stop();
            particleEffect3.Stop(); 
            particleEffect4.Stop();
            particleEffect5.Stop();


            engineOn = false;
            if (JetpackEngineSound.volume == 0.2f)
            {
                StartCoroutine(StartFade(JetpackEngineSound, 0.3f, 0));
            }
        }

        if (Physics.CheckSphere(groundCheck.transform.position, 0.3f, layer))
        {
            anim.SetBool("JetActive", false);          
        }

    }

    private void FixedUpdate()
    {
        switch (engineOn)
        {
            case true:
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                anim.SetBool("JetActive", true);

                break;
            case false:
                rb.AddForce(-Vector3.up * 1.5f, ForceMode.Impulse);
                break;
        }
    }

    public void Play()
    {
        anim.SetBool("IsRunning", true);
        playerSpeed = 8;
    }

    public void StopPlayer()
    {
        engineOn = false;
        playerSpeed = 0;
        anim.SetBool("IsRunning", false);
    }

    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }


    

}
