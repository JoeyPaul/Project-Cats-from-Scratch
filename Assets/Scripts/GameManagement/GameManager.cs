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
    public CameraMovement cameraMovement;
    private GameObject playerHealth;
    public StarterAssets.ThirdPersonController playerController;
    private GameObject pauseMenu;
    private GameObject gameOverMenu;
    private ScoreManager scoreManager;
    

    //-----Variables necessary for gameplay loops, win/loss states--//
    [Header("Game Variables")]
    public int score = 0;
    public int highScore;
    public bool isGameRunning;
    public bool isWalkModeActivated;


    void Start()
    {
        // Setting Bools
        isGameRunning = true;
        isWalkModeActivated = true;
        // Getting Components
        scoreManager = FindObjectOfType<ScoreManager>();
        playerHealth = FindObjectOfType<PlayerHealth>().gameObject;
        //cameraMovement = FindObjectOfType<CameraMovement>();
        //playerController = FindObjectOfType<StarterAssets.ThirdPersonController>();
        pauseMenu = GameObject.Find("PauseGameCanvas");
        gameOverMenu = GameObject.Find("GameOverCanvas");
        // Setting Menus
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        // Initial Settings
        cameraMovement.speed = CameraMovement.Speed.WALK;
        playerController.MoveSpeed = 2.5f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        // Testing Walk and Run mode.
        if (Input.GetKeyUp(KeyCode.F))
        {
            isWalkModeActivated = true;
            walkMode();
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            isWalkModeActivated = false;
            runMode();
        }
    }

    public void walkMode()
    {
        cameraMovement.speed = CameraMovement.Speed.WALK;
        playerController.MoveSpeed = 2.5f;
    }

    public void runMode()
    {
        cameraMovement.speed = CameraMovement.Speed.RUN;
        playerController.MoveSpeed = 7.0f;
    }

    public void EndGame()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0.0f;
        
        scoreManager.SaveHighScore();
    }

    // For use with the resume button in pause menu scene
    public void unPause()
    {
        Time.timeScale = 1f;
    }
}
