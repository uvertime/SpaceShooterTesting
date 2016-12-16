using UnityEngine;
using System.Collections;

public class UFOBullet : MonoBehaviour {

	public GameObject bullet;
	public GameObject[] bulletBox;
	private GameController gameController;
	private PlayerController playerController;
	public float fireRate;
	private float nextFire;
	public GameObject playerExplosion;
	public GameObject ufoBullet;

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
			Instantiate (ufoBullet, bulletBox[0].transform.position, bulletBox[0].transform.rotation);
			Instantiate (ufoBullet, bulletBox[1].transform.position, bulletBox[1].transform.rotation);
			Instantiate (ufoBullet, bulletBox[2].transform.position, bulletBox[2].transform.rotation);
			Instantiate (ufoBullet, bulletBox[3].transform.position, bulletBox[3].transform.rotation);
			Instantiate (ufoBullet, bulletBox[4].transform.position, bulletBox[4].transform.rotation);
			Instantiate (ufoBullet, bulletBox[5].transform.position, bulletBox[5].transform.rotation);
			Instantiate (ufoBullet, bulletBox[6].transform.position, bulletBox[6].transform.rotation);//as GameObject ;
			GetComponent<AudioSource>().Play ();
		}
	}
}
