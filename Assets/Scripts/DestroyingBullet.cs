using UnityEngine;
using System.Collections;

public class DestroyingBullet : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;
	private PlayerController playerController;
	public GameObject bulletDestroy;
	public GameObject bulletBox;
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
		if (other.tag == "Player"){
			/*if (Input.GetButton ("Dash")) {
				return;
			}
			else */
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}
		if (other.tag == "Boundary") {
			return;
		}
		if (other.tag == "enemy") {
			Instantiate (bulletDestroy, bulletBox.transform.position, bulletBox.transform.rotation);
			return;
		}

		Instantiate (explosion, transform.position, transform.rotation);

		Destroy(other.gameObject);
		Destroy(gameObject);
		Debug.Log ("masuk");

		gameController.AddScore (scoreValue);
	}

}
