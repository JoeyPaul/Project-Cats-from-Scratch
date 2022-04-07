using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //---------References to music & Sounds--------------------------// 
    [Header("Music References")]
    public AudioSource sceneMusic;
    public AudioSource gameOverMusic;
    public AudioSource pauseGameMusic;

    [Header("Character Sound References")]
    public AudioSource takeDamageSound; // Sounds for when player takes damage
    public AudioSource runningSound; // Character walking sound?? TODO: Delete if not necessary
    public AudioSource deathSound; // Sound when player dies, separate to the game over music

    [Header("Game Sound References")]
    public AudioSource powerUpSound; // Sound to play when player picks up health or points
    public AudioSource catSound; // Cat mewoing sound when it appears
    public AudioSource fallenTVSound; // TV hit ground sound when it falls

    //---------References to Components & game variables------------// 
    [Header("Component References")]
    public GameObject player;
    public GameObject pauseMenu;

    //-----Variables necessary for gameplay loops, win/loss states--//
    [Header("Game Variables")]
    public int score = 0;
    public int highScore;
    public bool isGameRunning;

    void Start()
    {
        isGameRunning = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu(pauseMenu.activeInHierarchy);
        }
    }

    public void TogglePauseMenu(bool pauseMenuState) // TODO: make this universal for other canvases
    {
        if (!pauseMenuState)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else if (pauseMenuState)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
        }    
    }
}
