using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject player;
    public GameObject gameOverUI;
    private GameController playerRef;

    private void Start()
    {
        playerRef = player.GetComponent<GameController>();
    }

    // Use this if your Death collider is NOT a trigger:
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // optional respawn:
            // player.transform.position = startPoint.transform.position;

            playerRef.GameOver();
            ShowGameOverUI();
        }
    }

    // Or if Death is set as a trigger, use this instead:
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         playerRef.GameOver();
    //         ShowGameOverUI();
    //     }
    // }

    private void ShowGameOverUI()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
        Cursor.visible = true;
    }

    // And hook these up to your GameOver buttons:
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToMenu(string menuSceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuSceneName);
    }
}
