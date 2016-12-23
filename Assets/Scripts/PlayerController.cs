using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
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
	public GameObject shotSpawn;
	public Transform shotSpawnLong;
	public float fireRate;
	private float dash;
	private PlayerController playerController;
	public GameObject bulletDestroyed;
	private float nextFire;
	private float nextFire2;
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

			Instantiate (shot, shotSpawn.transform.position, shotSpawn.transform.rotation); 
			if(gameController.lives >= 3){
				Instantiate (shot, shotSpawn.transform.position, Quaternion.Euler (0, 20, 0));
				Instantiate (shot, shotSpawn.transform.position, Quaternion.Euler (0, 340, 0));
			}
			if(gameController.lives >= 5){
				Quaternion shot4 = Quaternion.Euler (0, 30, 0);
				Quaternion shot5 = Quaternion.Euler (0, 330, 0);
				Instantiate (shot, shotSpawn.transform.position, shot4);
				Instantiate (shot, shotSpawn.transform.position, shot5);
			}
			GetComponent<AudioSource>().Play ();
		}



		if (Input.GetButton ("Fire2") && Time.time > nextFire2 && gameController.bombs > 0) {
			nextFire2 = Time.time + fireRate2;
			Quaternion shot1 = Quaternion.Euler (0, 0, 0);
			Quaternion shot2 = Quaternion.Euler (0, 20, 0);
			Quaternion shot3 = Quaternion.Euler (0, 40, 0);
			Quaternion shot4 = Quaternion.Euler (0, 340, 0);
			Quaternion shot5 = Quaternion.Euler (0, 320, 0);
			Instantiate (bulletDestroyed,shotSpawnLong.position,shot1);
			Instantiate (bulletDestroyed,shotSpawnLong.position,shot2);
			Instantiate (bulletDestroyed,shotSpawnLong.position,shot3);
			Instantiate (bulletDestroyed,shotSpawnLong.position,shot4);
			Instantiate (bulletDestroyed,shotSpawnLong.position,shot5);
			GetComponent<AudioSource> ().Play ();
			gameController.bombs = gameController.bombs - 1;
			gameController.UpdateBomb ();
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
		if (other.tag == "bomb") 
		{
			gameController.bombs = gameController.bombs + 1;
			gameController.UpdateBomb ();
		}
		if (other.tag == "radiostrontium") {
			SceneManager.LoadScene ("Congrats");//scene final
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
