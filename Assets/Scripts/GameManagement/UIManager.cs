using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI scoreValueText;
    
    private ScoreManager scoreManager;
    
    private void Start() {
        scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.OnScoreUpdated += UpdateScoreUI;
        
        UpdateScoreUI(scoreManager.CurrentScore);
    }

    private void UpdateScoreUI(int currentScore) {
        // Debug.Log(":: update score ui :: " + currentScore);
        scoreValueText.text = currentScore.ToString();
    }
}
