using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class CharacterSelection : MonoBehaviour
{
    private GameObject[] characterlist;
    private int index;
    public JetpackInfo[] Jetpacks;
    public Button BuyButton;
    public Button EquipButton;
    void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelect");
        characterlist = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            characterlist[i] = transform.GetChild(i).gameObject;
        }
        foreach (GameObject jp in characterlist)
        {
            jp.SetActive(false);

        }

        if (characterlist[index])
        {
        characterlist[index].SetActive(true);
        }

        foreach (JetpackInfo jps in Jetpacks)
        {
            if (jps.price == 0)
            {
                jps.IsUnlocked = true;
            }
            else
            {
                jps.IsUnlocked = PlayerPrefs.GetInt(jps.name, 0) == 0 ? false : true;
            }
        }

       
    }
    private void Update()
    {
        UpdateUI();
    }
    public void ToggleLeft()
    {
        characterlist[index].SetActive(false);

        index--;
        if (index<0)
        {
            index = characterlist.Length - 1;
        }

        characterlist[index].SetActive(true);
    }

    public void ToggleRight()
    {
        characterlist[index].SetActive(false);

        index++;
        if (index == characterlist.Length)
        {
            index = 0;
        }

        characterlist[index].SetActive(true);
    }

    public void EquipModel()
    {
        PlayerPrefs.SetInt("CharacterSelect", index);

    }

    public void UnlockJetpack()
    {
       
        JetpackInfo j = Jetpacks[index];

        PlayerPrefs.SetInt(j.name, 1);
        PlayerPrefs.SetInt("CharacterSelect", index);
        j.IsUnlocked = true;
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - j.price);
    }

    private void UpdateUI()
    {
        JetpackInfo j = Jetpacks[index];

        if (j.IsUnlocked)
        {
            if (BuyButton != null)
            {
                BuyButton.gameObject.SetActive(false); 
            }

            if (EquipButton != null)
                EquipButton.gameObject.SetActive(true);
        }
        else
        {
            if (BuyButton != null)
                BuyButton.gameObject.SetActive(true);
            if (EquipButton != null)
                EquipButton.gameObject.SetActive(false);
            BuyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy - " + j.price;
            if (j.price < PlayerPrefs.GetInt("Coin")) 
            {
                BuyButton.interactable = true;
            }
            else
            {
                BuyButton.interactable = false;
            }

            
        }
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SaveLevel"));
    }
}
