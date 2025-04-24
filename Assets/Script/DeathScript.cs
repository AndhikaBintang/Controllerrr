using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    [Tooltip("Drag & drop panel GameOver UI di sini")]
    public GameObject gameOverUI;
    [Tooltip("(Optional) titik respawn jika mau pake respawn")]
    public Transform startPoint;

    void Start()
    {
        Cursor.visible = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 1) Cek tag Player
        if (!other.CompareTag("Player")) return;

        

        // 3) Panggil GameOver di GameController
        var gc = other.GetComponent<GameController>();
        if (gc != null)
            gc.GameOver();

        // 4) Tampilkan UI
        Time.timeScale = 0f;
        if (gameOverUI != null)
            gameOverUI.SetActive(true);
        Cursor.visible = true;
    }

    // Tombol UI
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
