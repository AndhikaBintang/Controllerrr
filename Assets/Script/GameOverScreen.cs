using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameOverScreen : MonoBehaviour
{

    [SerializeField]TMP_Text Shards;
    [SerializeField] GameObject overScreen;

    
    public void setup(int score)
    {
        overScreen.SetActive(true);
        Shards.text = score.ToString() + "Shards";
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("New Stage");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}