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
    private GameObject player;
    private StarterAssets.ThirdPersonController playerController;
    private GameObject pauseMenu;
    private GameObject gameOverMenu;
    private ScoreManager scoreManager;
    private CameraMovement cameraMove;

    //-----Variables necessary for gameplay loops, win/loss states--//
    [Header("Game Variables")]
    public int score = 0;
    public int highScore;
    public bool isGameRunning;

    // todo move this to player?
    [SerializeField] private float playerWalkSpeed = 2.5f;
    [SerializeField] private float playerRunSpeed = 7.0f;

    void Start()
    {
        isGameRunning = true;
        scoreManager = FindObjectOfType<ScoreManager>();
        cameraMove = FindObjectOfType<CameraMovement>();
        playerController = FindObjectOfType<StarterAssets.ThirdPersonController>();
        player = FindObjectOfType<PlayerHealth>().gameObject;
        pauseMenu = GameObject.Find("PauseGameCanvas");
        gameOverMenu = GameObject.Find("GameOverCanvas");
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        sceneMusic.Play();

        playerController.MoveSpeed = playerWalkSpeed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            WalkMode();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RunMode();
        }
    }

    public void WalkMode()
    {
        cameraMove.speed = CameraMovement.Speed.WALK;
        playerController.MoveSpeed = playerWalkSpeed;
    }

    public void RunMode()
    {
        cameraMove.speed = CameraMovement.Speed.RUN;
        playerController.MoveSpeed = playerRunSpeed;
    }

    public void EndGame()
    {
        sceneMusic.Pause();
        gameOverMenu.SetActive(true);
        Time.timeScale = 0.0f;
        gameOverMusic.Play();
        
        scoreManager.SaveHighScore();
    }

    // For use with the resume button in pause menu scene
    public void unPause()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
}
