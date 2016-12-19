using UnityEngine;
using System.Collections;

public class MultiBulletSpawner : MonoBehaviour {

	public GameObject bullet;
	public GameObject bulletBox;
	private GameController gameController;
	private PlayerController playerController;
	public float fireRate;
	private float nextFire;
	public GameObject playerExplosion;


	void Update () {

		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Quaternion shot1 = Quaternion.Euler (0, 0, 0);
			Quaternion shot2 = Quaternion.Euler (0, 30, 0);
			Quaternion shot3 = Quaternion.Euler (0, 330, 0);
			Instantiate (bullet, bulletBox.transform.position, shot1); 
			Instantiate (bullet, bulletBox.transform.position, shot2);
			Instantiate (bullet, bulletBox.transform.position, shot3);
			GetComponent<AudioSource>().Play ();
		}
	}
}