using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICatController : MonoBehaviour {

    [SerializeField] private float detectionRadius = 5.0f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float chasePlayerTime = 3.0f;
    [SerializeField] private int damageCausedToPlayerOnTouch; // todo remove if unused
    [SerializeField] private float timeInCrazyMode = 5.0f;

    private Transform target;
    private float currentChaseTime;
    private bool chasingPlayer;
    private bool stopChasing;
    private bool inCrazyMode;

    private GameManager gameManager;
    
    private void Start() {
        gameManager = FindObjectOfType<GameManager>();
        target = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate() {
        if (stopChasing) {
            return;
        }

        DetectPlayer();
    }

    private void DetectPlayer() {
        RaycastHit hit;

        RaycastHit[] hits = Physics.SphereCastAll(transform.position, detectionRadius, Vector3.up, 
            0, playerLayer);
        bool hitPlayer = false;
        foreach (RaycastHit raycastHit in hits) {
            if (raycastHit.collider.CompareTag("Player")) {
                Debug.Log(":: sphere hit :: " + raycastHit.collider.name);
                hitPlayer = true;
            }
        }

        if (hitPlayer) {
            chasingPlayer = true;
        } else {
            chasingPlayer = false;
        }
    }

    private void Update() {
        if (!chasingPlayer) {
            return;
        }

        if (chasingPlayer) {
            currentChaseTime += Time.deltaTime;
            if (currentChaseTime >= chasePlayerTime) {
                StopChasingPlayer();
                return;
            }
            ChasePlayer();
        }
    }

    private void ChasePlayer() {
        Debug.Log(":: chase ::");
        Vector3 moveToPosition = target.position;
        moveToPosition.y = transform.position.y;
        transform.position = Vector3.MoveTowards(transform.position, moveToPosition, moveSpeed * Time.deltaTime);
    }

    private void StopChasingPlayer() {
        stopChasing = true;
        currentChaseTime = 0.0f;
        chasingPlayer = false;
        Debug.Log(":: stop chasing :: ");
        StartCoroutine(ResetChaseValues());
    }

    private IEnumerator ResetChaseValues() {
        yield return new WaitForSeconds(1.5f);
        stopChasing = false;
        Debug.Log(":: reset values ::");
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    // private void OnCollisionEnter(Collision collision) {
    //     if (collision.gameObject.CompareTag("Player")
    //         && !inCrazyMode) {
    //         Debug.Log(":: ====== collision crazy mode ");
    //         inCrazyMode = true;
    //         gameManager.RunMode();
    //         StartCoroutine(ResetGameMode());
    //     }
    // }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")
            && !inCrazyMode) {
            Debug.Log(":: ====== trigger crazy mode ");
            inCrazyMode = true;
            gameManager.RunMode();
            StopChasingPlayer();
            StartCoroutine(ResetGameMode());
        }
    }

    private IEnumerator ResetGameMode() {
        yield return new WaitForSeconds(timeInCrazyMode);
        Debug.Log(":: == back to walk mode");
        gameManager.WalkMode();
        inCrazyMode = false;
    }
}
