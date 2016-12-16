using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour {

	public GameObject bullet;
	public GameObject bulletBox;
	private GameController gameController;
	private PlayerController playerController;
	public float fireRate;
	private float nextFire;
	public GameObject playerExplosion;

	/*void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
			Destroy (other.gameObject);
			Destroy (gameObject);
		}

	}*/

	void Update () {

		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			//GameObject clone = 
			Instantiate (bullet, bulletBox.transform.position, bulletBox.transform.rotation); //as GameObject ;
			GetComponent<AudioSource>().Play ();
		}
	}
}
