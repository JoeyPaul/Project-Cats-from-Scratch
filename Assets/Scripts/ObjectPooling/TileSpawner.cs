using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileSpawner : MonoBehaviour {

    [SerializeField] private float xPositionOffset = 56.2f;
    [SerializeField] private float startXPosition = 18.4f;
    [SerializeField] private int numberOfTilesToPlaceAtStart = 2;
    
    private float currentXPosition;
    private ObjectPooler objectPooler;

    private List<GameObject> tiles;
    
    private void Start() {
        tiles = new List<GameObject>();
        objectPooler = GetComponent<ObjectPooler>();
        currentXPosition = startXPosition;

        for (int i = 0; i < numberOfTilesToPlaceAtStart; i++) {
            PlaceTile();
        }
    }

    private void PlaceTile() {
        GameObject tile = objectPooler.GetPooledObject();
        currentXPosition += xPositionOffset;
        Vector3 tilePosition = new Vector3(currentXPosition, 0.0f, 1.31f); // todo get these from elsewhere
        tile.transform.position = tilePosition;
        tiles.Add(tile);
    }

    private void RemoveTile() {
        if (!tiles.Any()) {
            return;
        }

        if (tiles.Count <= 4) { // todo remove magic number
            return;
        }
        
        GameObject tile = tiles[0];
        if (tile != null) {
            tiles.RemoveAt(0);
            objectPooler.ReturnObjectToPool(tile);
        }
    }

    public void UpdateTiles() {
        PlaceTile();
        RemoveTile();
    }
}
