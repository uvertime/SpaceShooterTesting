using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	//public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;
	private PlayerController playerController;


	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot Find 'GameController' script");
		
		}
	}



	void OnTriggerEnter(Collider other){
		
		if (other.tag == "Boundary") {
			return;
		}
		if (other.tag == "enemy") {
			return;
		}
		if (other.tag == "powerup") {
			return;
		}
		if (other.tag == "bomb") {
			return;
		}
		if (other.tag == "radiostrontium") {
			return;
		}
		if (other.tag == "Player") {
			//Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		} else {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);
			if(other.tag != "powershot")Destroy (other.gameObject);
			gameController.AddScore (scoreValue);
			DontDestroyOnLoad (transform.gameObject);
		}
	}

}
