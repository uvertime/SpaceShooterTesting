using UnityEngine;
using System.Collections;

public class DestroyByBullet : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
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
			return;
		}

		Instantiate (explosion, transform.position, transform.rotation);

		Destroy(other.gameObject);
		Destroy(gameObject);
	}

}
