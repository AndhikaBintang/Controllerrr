using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameOverScreen : MonoBehaviour
{

    [SerializeField]TMP_Text Shards;
        
    public void setup(int score)
    {
        gameObject.SetActive(true);
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