using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBeheaviour : MonoBehaviour {

	public Transform[] treePositions;
	public GameObject[] treePrefabs;
	public Transform[] coinPositions;
	public GameObject coinPrefab;
	public bool emptyPlane;
	public bool willSpawnCoins;

	// Use this for initialization
	void Start () {
		spawnTrees();
		if(willSpawnCoins) spawnCoins();
	}
	
	void spawnTrees(){
		for(int i =0; i < treePositions.Length; i++){
			if(Random.Range(0,2) == 0) {
				int k =Random.Range(0,treePrefabs.Length);
				GameObject tempTree = Instantiate(treePrefabs[k], treePositions[i].position,treePrefabs[k].transform.rotation);
				tempTree.transform.SetParent(transform);
			}
		}
	}

	void spawnCoins(){
		for(int i =0; i < coinPositions.Length; i++){
			if(emptyPlane){
				spawnCoin(i);
			}
			else{
				if(Random.Range(0,2) == 0) {
					spawnCoin(i);		
				}
			}
		}
	}

	void spawnCoin(int i){
					GameObject tempCoin = Instantiate(coinPrefab, coinPositions[i].position,coinPrefab.transform.rotation);
					tempCoin.transform.SetParent(transform);
	}

}
