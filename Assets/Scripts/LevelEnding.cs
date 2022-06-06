using System.Collections;
using UnityEngine;


public class LevelEnding : MonoBehaviour
{
    [SerializeField] PlayerMovementRb player;

    [SerializeField] Animator anim;

    [SerializeField] SwitchCamera switchCamera;

    [SerializeField] GameObject endScreen;
    [SerializeField] GameObject gameHud;
    [SerializeField] ParticleSystem FireWork;
    private GameObject particleEffect1;
    private GameObject particleEffect2;
    private GameObject particleEffect3;
    private GameObject particleEffect4;
    private GameObject particleEffect5;

    private AudioSource WinSound;

    int randomNumber;

    GameHandler gameHandler;

    private void Start()
    {
        FireWork.Stop();
        WinSound = GetComponent<AudioSource>();
        particleEffect1 = GameObject.Find("Jetpack (1)");
        particleEffect2 = GameObject.Find("Jetpack (2)");
        particleEffect3 = GameObject.Find("Jetpack (3)");
        particleEffect4 = GameObject.Find("Jetpack (4)");
        particleEffect5 = GameObject.Find("Jetpack (5)");

        gameHandler = FindObjectOfType<GameHandler>();
        
    }

    private void Update()
    {
        randomNumber = Random.Range(1, 9);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //particleEffect.SetActive(false);
            if(particleEffect1 != null)
            particleEffect1.SetActive(false);

            if (particleEffect2 != null)
                particleEffect2.SetActive(false);

            if (particleEffect3 != null)
                particleEffect3.SetActive(false);

            if (particleEffect4 != null)
                particleEffect4.SetActive(false);

            if (particleEffect5 != null)
                particleEffect5.SetActive(false);

            player.JetpackEngineSound.Stop();
            WinSound.Play();
            player.isFinish = true;
            player.StopPlayer();

            FireWork.Play();

            PlayerPrefs.SetInt("Coin", gameHandler.Coin);
            //Play ending Animation
            if (randomNumber == 1)
            {
                anim.Play("Dance1");
            }
            else if (randomNumber == 2)
            {
                anim.Play("Dance2");
            }
            else if (randomNumber == 3)
            {
                anim.Play("Dance3");
            }
            else if (randomNumber == 4)
            {
                anim.Play("Dance4");
            }
            else if (randomNumber == 5)
            {
                anim.Play("Dance5");
            }
            else if (randomNumber == 6)
            {
                anim.Play("Dance6");
            }
            else if (randomNumber == 7)
            {
                anim.Play("Dance7");
            }
            else
            {
                anim.Play("Dance8");
            }

            //Switch Camera
            switchCamera.SwitchEndCamera();


            //Open EndingScreen
            gameHud.SetActive(false);
            StartCoroutine(EndScreen());

        }
    }

    IEnumerator EndScreen()
    {
        yield return new WaitForSeconds(4);
        endScreen.SetActive(true);
    }
}
