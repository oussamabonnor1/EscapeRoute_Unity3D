using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject[] planePrefab;
	public int planesCount = 50;
	Vector3 spawnPosition;

	// Use this for initialization
	void Start () {
		spawnPosition = new Vector3(0f,planePrefab[0].transform.position.y,planePrefab[0].transform.position.z);
		makePlanes();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void makePlanes(){
		for(int i = 0; i< planesCount; i++){
			int index = Random.Range(0,planePrefab.Length);
			Instantiate(planePrefab[index], spawnPosition, planePrefab[index].transform.rotation);
			spawnPosition = new Vector3(spawnPosition.x + 10,spawnPosition.y,spawnPosition.z);
		}
	}

	public void restart(){
		SceneManager.LoadScene("Main");
	}
	public void quit(){
		Application.Quit();
	}
}
