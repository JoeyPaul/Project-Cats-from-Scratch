using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI scoreValueText;
    [SerializeField] private TextMeshProUGUI highScoreValueText;
    [SerializeField] private TextMeshProUGUI playerLifeValueText;
    
    private ScoreManager scoreManager;
    private PlayerHealth playerHealth;
    
    private void Start() {
        scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.OnScoreUpdated += UpdateScoreUI;
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        playerHealth.OnUpdateHealth += UpdateHealthValue;
        
        UpdateScoreUI(scoreManager.CurrentScore);

        highScoreValueText.text = scoreManager.HighScore.ToString();
        UpdateHealthValue();
    }

    private void UpdateHealthValue() {
        playerLifeValueText.text = playerHealth.health.ToString();
    }

    private void UpdateScoreUI(int currentScore) {
        scoreValueText.text = currentScore.ToString();
    }
}
