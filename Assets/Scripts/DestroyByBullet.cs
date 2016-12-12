using UnityEngine;
using System.Collections;

public class DestroyByBullet : MonoBehaviour {
	public GameObject playerExplosion;
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
		if (other.tag == "enemy"){
			/*if (Input.GetButton ("Dash")) {
				return;
			}
			else */
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}
		if(other.tag == "Player"){
			return;
		}
		Destroy(other.gameObject);
		Destroy(gameObject);
		Debug.Log ("masuk");

	}

}
