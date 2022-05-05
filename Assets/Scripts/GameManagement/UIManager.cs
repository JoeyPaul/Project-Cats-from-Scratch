using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI scoreValueText;
    [SerializeField] private TextMeshProUGUI highScoreValueText;
    
    private ScoreManager scoreManager;
    
    private void Start() {
        scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.OnScoreUpdated += UpdateScoreUI;
        
        UpdateScoreUI(scoreManager.CurrentScore);

        highScoreValueText.text = scoreManager.HighScore.ToString();
    }

    private void UpdateScoreUI(int currentScore) {
        scoreValueText.text = currentScore.ToString();
    }
}
