using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroStartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(4);
        if (PlayerPrefs.GetInt("SaveLevel") == 0)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("SaveLevel"));
        }
    }
}
