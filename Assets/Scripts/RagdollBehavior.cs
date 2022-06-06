using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RagdollBehavior : MonoBehaviour
{

    [SerializeField] GameObject parent;
    [SerializeField] GameObject playerMesh;

    [SerializeField] GameObject child;
    [SerializeField] GameObject bone;

    [SerializeField] GameObject reviveChild;
    [SerializeField] GameObject boneRevive;

    [SerializeField] Animator anim;
    [SerializeField] Animator animRevive;

    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject Hud;
    [SerializeField] Button reviveButton;
    [SerializeField] GameObject countDownBg;

    [SerializeField] AudioSource LossSound;
    [SerializeField] AudioSource HitSound;

    GameHandler gameHandler;

    private PlayerMovementRb player;
    public bool isRevive;
    private int ReviveCount;
    
    public bool isDie;
    private bool doOnce = true;

    private void Start()
    {
        player = parent.GetComponent<PlayerMovementRb>();
        gameHandler = FindObjectOfType<GameHandler>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (doOnce && collision.collider.CompareTag("Obstacle") || collision.collider.CompareTag("OtherObstacles"))
        {
            if (collision.collider.CompareTag("OtherObstacles"))
            {
                countDownBg.SetActive(false);
                reviveButton.interactable = false;

            }
            else if (collision.collider.CompareTag("Obstacle"))
            {
                Destroy(collision.collider.gameObject, 0.5f);
            }

            isDie = true;
            PlayerPrefs.SetInt("Coin", gameHandler.Coin);

            if (child != null)
            {
                Handheld.Vibrate();

                child.transform.SetParent(null);
                child.SetActive(true);

                player.playerSpeed = 0;

                playerMesh.SetActive(false);

                bone.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1) * 50, ForceMode.Impulse);

                StartCoroutine(Delay());

                gameOverScreen.SetActive(true);
                Hud.SetActive(false);

                HitSound.Play();
                LossSound.PlayDelayed(1.0f);

                doOnce = false;
            }

            if (isRevive)
            {
                Handheld.Vibrate();

                reviveChild.transform.SetParent(null);
                reviveChild.SetActive(true);

                player.playerSpeed = 0;
                playerMesh.SetActive(false);

                boneRevive.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1) * 50, ForceMode.Impulse);

                StartCoroutine(DelaySecond());

                gameOverScreen.SetActive(true);
                Hud.SetActive(false);

            }
        }
    }


    public void Revive()
    {
        doOnce = true;
        isRevive = true;
        Time.timeScale = 1;


        parent.transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y, parent.transform.position.z - 10);
        playerMesh.SetActive(true);
 
        ReviveCount++;

        if (ReviveCount == 1)
        {
            reviveButton.interactable = false;
        }
    }


    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.05f);
        anim.enabled = false;
    }

    IEnumerator DelaySecond()
    {
        yield return new WaitForSeconds(0.05f);
        animRevive.enabled = false;
    }
}
