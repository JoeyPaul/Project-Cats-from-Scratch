using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    [SerializeField] private int walkScorePerSecond = 1;
    [SerializeField] private int runScorePerSecond = 5;
    [SerializeField] private int bonusScore = 10;
    [SerializeField] private float incrementScoreEverySeconds = 1.0f;
    [SerializeField] private float giveBonusEverySeconds = 30.0f;

    public event Action<int> OnScoreUpdated;

    private const string HIGH_SCORE_PREF = "HighScore";

    private int currentScore;
    private int highScore;
    private float lastScoreUpdateTime;
    private float lastBonusUpdateTime;

    private CameraMovement cameraMovement;

    public int CurrentScore => currentScore;
    public int HighScore => highScore;

    private void Awake() {
        if (PlayerPrefs.HasKey(HIGH_SCORE_PREF)) {
            highScore = PlayerPrefs.GetInt(HIGH_SCORE_PREF);
        } else {
            highScore = 0;
        }
    }

    private void Start() {
        cameraMovement = FindObjectOfType<CameraMovement>();
        currentScore = 0;
        UpdateScore(currentScore);
    }

    private void Update() {
        if (Time.time - lastScoreUpdateTime >= incrementScoreEverySeconds) {
            if (cameraMovement.speed == CameraMovement.Speed.WALK) {
                UpdateScore(walkScorePerSecond);
            } else if (cameraMovement.speed == CameraMovement.Speed.RUN) {
                UpdateScore(runScorePerSecond);
            }

            lastScoreUpdateTime = Time.time;
        }

        if (Time.time - lastBonusUpdateTime >= giveBonusEverySeconds) {
            UpdateScore(bonusScore);
            lastBonusUpdateTime = Time.time;
        }
    }

    private void UpdateScore(int updateScore) {
        currentScore += updateScore;
        OnScoreUpdated?.Invoke(currentScore);
    }

    public void SaveHighScore() {
        if (PlayerPrefs.HasKey(HIGH_SCORE_PREF)) {
            int highScore = PlayerPrefs.GetInt(HIGH_SCORE_PREF);
            if (currentScore > highScore) {
                PlayerPrefs.SetInt(HIGH_SCORE_PREF, currentScore);
            }
        } else {
            PlayerPrefs.SetInt(HIGH_SCORE_PREF, currentScore);
        }
    }
    
    public void DecreaseScore(int value) {
        currentScore -= value;

        if (currentScore < 0) {
            currentScore = 0;
        }
        
        OnScoreUpdated?.Invoke(currentScore);
    }
}
