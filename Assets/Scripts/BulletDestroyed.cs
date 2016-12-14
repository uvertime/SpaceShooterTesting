using UnityEngine;
using System.Collections;

public class BulletDestroyed : MonoBehaviour {

	public GameObject bullet;
	public GameObject bulletBox;
	private GameController gameController;
	private PlayerController playerController;
	public float fireRate;
	private float nextFire;
	public GameObject playerExplosion;
	public GameObject bulletDestroy;
	/*void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			Instantiate (bulletDestroy, bulletBox.transform.position, bulletBox.transform.rotation);
		}
	}*/

	void Update () {

		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			//GameObject clone = 
			Instantiate (bulletDestroy, bulletBox.transform.position, bulletBox.transform.rotation); //as GameObject ;
			//GetComponent<AudioSource>().Play ();
		}
	}
}
