using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TMP_Text currentLevel;
    [SerializeField] TMP_Text nextLevel;
    [SerializeField] TMP_Text nextLevel2;


    // Start is called before the first frame update
    void Start()
    {
        currentLevel.SetText(SceneManager.GetActiveScene().buildIndex.ToString());
        nextLevel.SetText((SceneManager.GetActiveScene().buildIndex + 1).ToString());
        nextLevel2.SetText((SceneManager.GetActiveScene().buildIndex + 2).ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
