using UnityEngine;
using System.Collections;

public class BossHP : MonoBehaviour {

	private int hitpoints=200;
	private GameController gameController;
	public GameObject explosion;


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

		if (hitpoints > 0) 
		{
			hitpoints = hitpoints - 1;
			Instantiate (explosion, transform.position, transform.rotation);
		}
		else {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);
			Destroy (other.gameObject);
			gameController.bossdone = true;
		}
	}
}
