using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class ObjectPoolItem {

	public GameObject objectToPool;
	public int amountToPool;
	public bool shouldExpand;

	public ObjectPoolItem(GameObject poolObj, int count, bool expand = true) {
		objectToPool = poolObj;
		amountToPool = Mathf.Max(count,2);
		shouldExpand = expand;
	}
}

public class ObjectPooler : MonoBehaviour {
	
	[SerializeField] private string poolName;
	[SerializeField] List<ObjectPoolItem> itemsToPool;
	public List<GameObject> pooledObjects;
	
	private void Awake () {
		pooledObjects = new List<GameObject>();
		
		AddObjectsToPool();
	}

	private void AddObjectsToPool() {
		foreach (ObjectPoolItem item in itemsToPool) {
			for (int i = 0; i < item.amountToPool; i++) {
				GameObject go = (GameObject)Instantiate(item.objectToPool);
				go.SetActive(false);
				pooledObjects.Add(go);
			}
		}

		// https://stackoverflow.com/questions/273313/randomize-a-listt
		pooledObjects = pooledObjects.OrderBy(x => Guid.NewGuid()).ToList();
	}
	
	public GameObject GetPooledObject() {
		for (int i = 0; i < pooledObjects.Count; i++) {
			int index = Random.Range(0, pooledObjects.Count);
			if (!pooledObjects[index].activeInHierarchy) {
				pooledObjects[index].SetActive(true);
				return pooledObjects[index];
			}
		}

		ObjectPoolItem item = itemsToPool[Random.Range(0, itemsToPool.Count)];
		if (item.shouldExpand) {
			GameObject obj = (GameObject)Instantiate(item.objectToPool);
			obj.SetActive(true);
			pooledObjects.Add(obj);
			return obj;
		}
		
		return null;
	}

	public void ReturnObjectToPool(GameObject poolItem) {
		poolItem.SetActive(false);
	}
}