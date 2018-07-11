using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class HelicopterBehaviour : MonoBehaviour {

	public Transform transformToRotate;
	public Animator chopperAnimator, fanAnimator, leftArrow, rightArrow;
	public GameObject explosionPrefab;
	public GameObject fire;
	public Text scoreText;
	public Text loseText;
	public GameObject losePanel;
	public float speed =4f;
	public float movingSpeed = 4f;
	int score;
	public bool gameOver;
	public bool gameStarted;
	float screenWidth;
	float zAxisTranslate, xAxisRotation, yAxisRotation;
	Quaternion rotationTarget;

	// Use this for initialization
	void Start () {
		screenWidth = Screen.width/2;

	}
	
	// Update is called once per frame
	void Update () {
		if(!gameStarted){
			if(Input.GetMouseButtonDown(0)) {
				gameStarted = true;
				Camera.main.gameObject.GetComponent<Animator>().enabled = false;
				Camera.main.gameObject.GetComponent<CameraBehaviour>().calculateOffset();
				Camera.main.gameObject.GetComponent<CameraBehaviour>().gameStarted = true;
				leftArrow.enabled = rightArrow.enabled = true;
			}
		}
		if(!gameOver && gameStarted){
			movingSpeed += Time.deltaTime / 10;
			speed += Time.deltaTime /15;
			zAxisTranslate = 0;
			xAxisRotation = yAxisRotation = 0f;
			if(Input.GetMouseButton(0)){
				if(Input.mousePosition.x <= screenWidth){
						zAxisTranslate = Time.deltaTime;
						xAxisRotation = 15f;
						yAxisRotation = -5f;
					}else {
						zAxisTranslate = -Time.deltaTime;
						xAxisRotation = -15f;
						yAxisRotation = 5f;
					}
			}
			//Handling the rotation
			rotationTarget = Quaternion.Euler(xAxisRotation, yAxisRotation, -20f);
			transformToRotate.rotation = Quaternion.Slerp(transformToRotate.rotation, rotationTarget, 10* Time.deltaTime);

			//Handling the moves
			transform.Translate(new Vector3(movingSpeed * Time.deltaTime,0f,speed * zAxisTranslate));
			transform.position = new Vector3(transform.position.x,transform.position.y,Mathf.Clamp(transform.position.z,-2.5f,2.5f));
		}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag.Equals("rock") && !gameOver) selfExplode();
		if(other.gameObject.tag.Equals("coin") && !gameOver) {
			score++;
			scoreText.text = "Score: "+score;
			Destroy(other.gameObject);
		}
	}

	void selfExplode(){
		gameOver = true;
		Instantiate(explosionPrefab, transform.position, transform.rotation);
		fire.SetActive(true);
		chopperAnimator.enabled = false;
		fanAnimator.enabled = false;
		GetComponent<Rigidbody>().useGravity = true;
		losePanel.SetActive(true);
		loseText.text = "Game over!\nScore: "+score+"\nBest score: 25";
	}
}
