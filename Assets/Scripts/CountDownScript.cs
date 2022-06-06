using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountDownScript : MonoBehaviour
{
    private float countDownAmount = 5;

    [SerializeField] TMP_Text countdownText;

    [SerializeField] RagdollBehavior ragdollBehavior;

    public bool IsAdsRunning;

    // Update is called once per frame
    void Update()
    {
        countdownText.SetText(countDownAmount.ToString("0"));

        if (ragdollBehavior.isDie)
        {
            if (countDownAmount > 0)
            {
                countDownAmount -= Time.unscaledDeltaTime;
            }
            else if (countDownAmount < 0 && IsAdsRunning == false)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void CheckAds()
    {
        IsAdsRunning = true;

    }
}
