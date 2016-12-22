using UnityEngine;
using System.Collections;

public class BossHP : MonoBehaviour {

	private int hitpoints=200;
	private GameController gameController;
	public GameObject explosion;
	public float fireRate;
	private float nextFire;
	public GameObject bullet;
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
	void Update(){
		if (gameController.pola==15)
		{
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);
			gameController.bossdone = true;
		}


		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Quaternion shot1 = Quaternion.Euler (0, Random.Range(-80, 80), 0);
			Instantiate (bullet, bulletBox.transform.position, shot1); 
			GetComponent<AudioSource>().Play ();
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