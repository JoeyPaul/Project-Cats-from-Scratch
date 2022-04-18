using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawnPoint : MonoBehaviour {

    private TileSpawner tileSpawner;
    private bool hitPlayer;

    private void Start() {
        tileSpawner = FindObjectOfType<TileSpawner>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && !hitPlayer) {
            hitPlayer = true;
            tileSpawner.UpdateTiles();
        }
    }
}
