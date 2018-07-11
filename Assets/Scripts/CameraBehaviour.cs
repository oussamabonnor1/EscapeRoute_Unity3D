using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

	public Transform target;
	public Vector3 offSet;
	public float speed = 3f;
	public bool gameStarted = false;

	// Update is called once per frame
	void LateUpdate () {
		if(gameStarted) transform.position = Vector3.Lerp(transform.position, target.position + offSet, speed * Time.deltaTime);
	}

	public void calculateOffset(){
		offSet = transform.position - target.position;
	}
}
