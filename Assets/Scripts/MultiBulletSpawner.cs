using UnityEngine;
using System.Collections;

public class MultiBulletSpawner : MonoBehaviour {

	public GameObject bullet;
	public GameObject []bulletBox;
	private GameController gameController;
	private PlayerController playerController;
	public float fireRate;
	private float nextFire;
	public GameObject playerExplosion;


	void Update () {

		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (bullet, bulletBox[0].transform.position, bulletBox[0].transform.rotation); 
			Instantiate (bullet, bulletBox[1].transform.position, bulletBox[1].transform.rotation);
			Instantiate (bullet, bulletBox[2].transform.position, bulletBox[2].transform.rotation);
			GetComponent<AudioSource>().Play ();
		}
	}
}