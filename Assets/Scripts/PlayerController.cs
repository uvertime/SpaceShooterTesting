using UnityEngine;
using System.Collections;
[System.Serializable]
public class Boundary
{
	public float xMin,xMax,zMin,zMax;
}

public class PlayerController : MonoBehaviour {
	public GameController gameController;
	public GameObject playerExplosion;
	public float speed;
	public float tilt;
	public Boundary boundary;
	public GameObject shot;
	public GameObject[] shotSpawn;
	public Transform shotSpawnLong;
	public float fireRate;
	private float dash;
	private PlayerController playerController;
	public GameObject bulletDestroyed;
	private float nextFire;
	public float fireRate2;
	public float invultime;
	private float nextinvul;
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
	void Update()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn[0].transform.position, shotSpawn[0].transform.rotation); 
			if(gameController.lives >= 3){
				Quaternion shot2 = Quaternion.Euler (0, 30, 0);
				Quaternion shot3 = Quaternion.Euler (0, 330, 0);
				Instantiate (shot, shotSpawn[1].transform.position, shot2);
				Instantiate (shot, shotSpawn[2].transform.position, shot3);
			}
			if(gameController.lives >= 5){
				Instantiate (shot, shotSpawn[3].transform.position, shotSpawn[3].transform.rotation);
				Instantiate (shot, shotSpawn[4].transform.position, shotSpawn[4].transform.rotation);
			}
			GetComponent<AudioSource>().Play ();
		}



		if (Input.GetButton ("Fire2") && Time.time > nextFire) {
			nextFire = Time.time + fireRate2;
			Instantiate (bulletDestroyed,shotSpawnLong.position,shotSpawnLong.rotation);
			GetComponent<AudioSource> ().Play ();
		}



	}

	void FixedUpdate  ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;
		GetComponent<Rigidbody> ().position = new Vector3
			(
				Mathf.Clamp (GetComponent<Rigidbody> ().position.x,boundary.xMin, boundary.xMax),
				0.0f,
				Mathf.Clamp (GetComponent<Rigidbody> ().position.z,boundary.zMin, boundary.zMax));
			if(Input.GetButton ("Dash") ){
				GetComponent<Rigidbody>().velocity = movement * 2 * speed;
			}
			
				GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody> ().velocity.x * -tilt);
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "powerup") 
		{
			gameController.lives = gameController.lives + 1;
			gameController.UpdateLives ();
		}

		if (other.tag == "enemy") 
		{
			Destroy (other.gameObject);
			if (gameController.lives > 1) 
			{
				if (nextinvul>Time.time) {
					return;
				}
				gameController.lives = gameController.lives - 1;
				gameController.UpdateLives ();
				nextinvul = Time.time + invultime;
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			} 
			else 
			{
				if (Time.time < nextinvul) {
					return;
				}
				gameController.lives = gameController.lives - 1;
				gameController.UpdateLives ();
				Destroy (gameObject);
				gameController.GameOver ();
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				nextinvul = Time.time + invultime;
			}

		}

	}
}
