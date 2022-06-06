using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameHandler : MonoBehaviour
{
    [HideInInspector] public int InterstitialSpawn;
    [SerializeField] GameObject SoundOn;
    [HideInInspector] public int Coin;

    [SerializeField] TMP_Text CoinText;
    [SerializeField] TMP_Text CoinTextShop;
    [SerializeField] TMP_Text CoinTextHud;


    private void Start()
    {
        
        //Check if the device cannot reach the internet
        if (PlayerPrefs.GetInt("MuteIndex") == 1)
        {
            AudioListener.volume = 1;
            SoundOn.SetActive(true);
        }
        else
        {
            AudioListener.volume = 0;
            SoundOn.SetActive(false);
        }

        InterstitialSpawn = PlayerPrefs.GetInt("Ad");
        Coin = PlayerPrefs.GetInt("Coin");
        if (CoinText != null)
            CoinText.text = PlayerPrefs.GetInt("Coin").ToString();

        if (CoinTextHud != null)
            CoinTextHud.text = PlayerPrefs.GetInt("Coin").ToString();

        if(CoinTextShop !=null)
            CoinTextShop.text = PlayerPrefs.GetInt("Coin").ToString();
    }

    private void Update()
    {
        CoinTextHud.text = Coin.ToString();
    }

    public void RestartLevel()
    {
        //Time.timeScale = 1;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("SaveLevel", SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
    }

    public void Mute()
    {
        if (PlayerPrefs.GetInt("MuteIndex") == 1)
        {
            AudioListener.volume = 0;
            PlayerPrefs.SetInt("MuteIndex", 0);
            SoundOn.SetActive(false);
        }
        else
        {
            AudioListener.volume = 1;
            PlayerPrefs.SetInt("MuteIndex", 1);
            SoundOn.SetActive(true);
        }
    }
    public void ScreenShot()
    {
        ScreenCapture.CaptureScreenshot("file",3);
    }

    public void LoadShop()
    {
        SceneManager.LoadScene("Shop");
    }

}
