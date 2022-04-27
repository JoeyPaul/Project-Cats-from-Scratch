using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Component References")]
    private SpriteRenderer playerSprite; // Temporary to show player death
    public GameManager gameManager;

    [Header("Health Settings")]
    public float health;
    private bool playerIsDead;
    private string gameOverReason;

    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        playerIsDead = false;
        health = 3.0f;
    }

    void Update()
    {
        if (health <= 0.0f && !playerIsDead)
        {
            gameOverReason = "You got hit too many times";
            //TODO: Add different reasons for why Game Over
            Debug.LogWarning("Ran into obstacles"); //TODO: Remove after testing
            Die(gameOverReason);
            gameManager.EndGame();
        }
    }

    // Edge of screen collision & obstacle collision
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ScreenEdge")
        {
            gameOverReason = "You were too slow";
            Debug.LogError("You were too slow"); //TODO: Remove after testing
            gameManager.EndGame();
            
        }
        if (other.gameObject.tag == "Obstacle")
        {
            health--;
            Debug.LogError("Hit obstacle"); //TODO: Remove after testing
        }
    }

    public void Die(string gameOverReasonText)
    {
        playerIsDead = true;
        //playerSprite.color = Color.black;
        // TODO: Play gameover animation in game manager
        // TODO: Play gameover sound & music
    }
}
