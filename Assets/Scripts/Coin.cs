using UnityEngine;

public class Coin : MonoBehaviour
{
    GameHandler gameHandler;
    [SerializeField] AudioClip coinSound;
    [SerializeField] GameObject coinShinee;
    private void Start()
    {
        gameHandler = FindObjectOfType<GameHandler>();
    }
    void Update()
    {
        gameObject.transform.Rotate(0, 80 * Time.deltaTime, 0, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameHandler.Coin += 100;
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            GameObject coinShine;
            coinShine = Instantiate(coinShinee, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(coinShine, 0.2f);
            Destroy(gameObject);
            Debug.Log(gameHandler.Coin);
        }
    }


    
}