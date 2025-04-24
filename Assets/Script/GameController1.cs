using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameOverScreen gameOverScreen; // perbaikan di sini
    int Player = 0;    
    

    public void GameOver()
    {
        gameOverScreen.setup(Player);
    }

    private void Awake()
    {
        // Contoh jika ingin mengambil komponen secara dinamis
         gameOverScreen = FindObjectOfType<GameOverScreen>();
    }

    void Start()
    {
        // Inisialisasi lainnya
    }

    void SpawnPlatforms()
    {
        // Logika spawn platform
    }

    void Spawn1More()
    {
        // Logika spawn satu platform lagi
    }

    public void TouchedPlatform(string name)
    {
        // Logika saat menyentuh platform
    }
}
