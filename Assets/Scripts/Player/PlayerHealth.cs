using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Component References")]
    private SpriteRenderer playerSprite; // Temporary to show player death
    private Rigidbody playerRb;
    private CapsuleCollider playerCollider; // TODO: change to box/sphere/capsule
    //TODO: Ref game cartridge/manager

    [Header("Health Settings")]
    public float health;
    private bool playerIsDead;
    private string gameOverReason;

    void Start()
    {
        playerIsDead = false;
        health = 3.0f;
        //playerRb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        if (health <= 0.0f && !playerIsDead)
        {
            gameOverReason = "You got hit too many times";
            //TODO: Add different reasons for why Game Over
            Debug.LogWarning("Ran into obstacles"); //TODO: Remove after testing
            Die(gameOverReason);
        }
    }

    // Edge of screen collision & obstacle collision
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ScreenEdge")
        {
            gameOverReason = "You were too slow";
            Debug.LogError("You were too slow"); //TODO: Remove after testing
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
        playerCollider.enabled = false;
        playerSprite.color = Color.black;
        // TODO: call a GameOver() in game manager
        // TODO: Play gameover animation in game manager
        // TODO: Play gameover sound & music
        // TODO: Start gameover screen
    }
}
