using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public GameObject[] hazard;
	public GameObject[] powerup;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GUIText scoreText;
	public GUIText playerlives;
	public GUIText bombcount;
	public  static int score;
	public  static int wavet;
	private  bool wavedone;
	public static int scorefinal;
	public static int wavefinal;
	public int lives;
	public int bombs;
	public GUIText WaveText;
	public GUIText restartText;
	public GUIText gameOverText;
	public bool bossdone;
	private bool bossdone2;
	private bool gameOver;
	private bool restart;
	void Start(){
		lives = 2;
		bombs = 2;
		gameOver = false;
		restart = false;
		bossdone = false;
		bossdone2 = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		wavet = 1;
		UpdateWave ();
		UpdateLives ();
		UpdateBomb ();
		StartCoroutine (SpawnWaves ());
	}

	void Update(){
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene ("main");
			}
		}
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while(true)
		{
			//Debug.Log ("MASUK SPAWNWAVE");
			wavedone=false;
			yield return new WaitForSeconds (waveWait);
			WaveText.text = "";
			wavedone = false;
			StartCoroutine (levelcount ());
			yield return new WaitUntil (()=>wavedone||gameOver);
			yield return new WaitForSeconds (waveWait);
			wavet++;
			if (gameOver) {
				restartText.text = "Press 'R' for Restart";
				restart = true ;
				break;
			}
			UpdateWave ();
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}


	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver(){
		gameOverText.text = "Game Over";
		gameOver = true;
		scorefinal = score;
		wavefinal = wavet;
		SceneManager.LoadScene ("Game Over");
		scoreText.text = "Score: " + score;
	}

	public void scoregameover(){
		scoreText.text = "Score: " + score;
	}

	void UpdateWave()
	{
		WaveText.text = "Wave " + wavet;
	}

	public void UpdateLives()
	{
		playerlives.text = "Lives : " + lives;
	}

	public void UpdateBomb()
	{
		bombcount.text = "Bomb : " + bombs;
	}


	// mulai dari sini adalah desain level


	IEnumerator levelcount ()
	{
		int chance = Random.Range (0, 100);
		if(chance>=83){
			Vector3 hore = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion hore2 = Quaternion.Euler (0, 180, 0);
			Instantiate (powerup [1], hore, hore2);
			yield return new WaitForSeconds ((float)0.5);
		}
			


		if(wavet%3==0){
		Vector3 hore = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
		Quaternion hore2 = Quaternion.Euler (0, 180, 0);
		Instantiate (powerup [0], hore, hore2);
		yield return new WaitForSeconds ((float)1.5);
		}

		if (wavet == 25) {
			int y = Random.Range (15, 20);
			for (int i = 0; i < y; i++) {
				int x = Random.Range (0, hazard.Length);
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.Euler (0, 180, 0);
				Instantiate (hazard [0], spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
		} else if (wavet == 2) {
			for (int i = 0; i < 6; i++) {
				int x = Random.Range (-1, 1);	
				Vector3 spawnPosition = new Vector3 (-5 + x, spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.Euler (0, 180, 0);
				Instantiate (hazard [0], spawnPosition, spawnRotation);
				x = Random.Range (-1, 2);
				spawnPosition = new Vector3 (5 + x, spawnValues.y, spawnValues.z);
				spawnRotation = Quaternion.Euler (0, 180, 0);
				Instantiate (hazard [0], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.1);
				x = Random.Range (-1, 1);
				spawnPosition = new Vector3 (-3 + x, spawnValues.y, spawnValues.z);
				spawnRotation = Quaternion.Euler (0, 180, 0);
				Instantiate (hazard [0], spawnPosition, spawnRotation);
				x = Random.Range (-1, 1);
				spawnPosition = new Vector3 (3 + x, spawnValues.y, spawnValues.z);
				spawnRotation = Quaternion.Euler (0, 180, 0);
				Instantiate (hazard [0], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.1);
				x = Random.Range (-2, 2);
				spawnPosition = new Vector3 (0 + x, spawnValues.y, spawnValues.z);
				spawnRotation = Quaternion.Euler (0, 180, 0);
				Instantiate (hazard [0], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.5);
			}
		} else if (wavet == 3) {
			int y = Random.Range (10, 15);
			for (int i = 0; i < y; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.Euler (0, 180, 0);
				Instantiate (hazard [0], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.9);
				if (i % 2 == 0) {
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					spawnRotation = Quaternion.Euler (0, 180, 0);
					Instantiate (hazard [1], spawnPosition, spawnRotation);
					yield return new WaitForSeconds ((float)0.1);
				}
			}
		} else if (wavet == 4) {
			for (int i = 0; i < 21; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, -7); //z=-7 itu dari belakang
				Quaternion spawnRotation = Quaternion.Euler (0, 0, 0);
				Instantiate (hazard [0], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.5);
				if (i % 3 == 0) {
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					spawnRotation = Quaternion.Euler (0, 180, 0);
					Instantiate (hazard [1], spawnPosition, spawnRotation);
					yield return new WaitForSeconds ((float)0.1);
				}
			}
		} else if (wavet == 5) {
			int y = Random.Range (30, 40);
			for (int i = 0; i < y; i++) {
				int x = Random.Range (1, 4);
				if (x % 2 == 1)
					x = 0;
				else
					x = 2;
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.Euler (0, 180, 0);
				Instantiate (hazard [x], spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
		} else if (wavet == 6) {
			for (int i = 0; i < 15; i++) {
				int x = Random.Range (1, 4);
				if (x % 2 == 1)
					x = 0;
				else
					x = 2;
				Vector3 spawnPosition = new Vector3 (Random.Range (-4, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.Euler (0, 240, 0);
				Instantiate (hazard [x], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.3);
				x = Random.Range (1, 4);
				if (x % 2 == 1)
					x = 0;
				else
					x = 2;
				spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, Random.Range (0, spawnValues.z));
				spawnRotation = Quaternion.Euler (0, 240, 0);
				Instantiate (hazard [x], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.3);
				x = Random.Range (1, 4);
				if (x % 2 == 1)
					x = 0;
				else
					x = 2;
				spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, Random.Range (0, 10));
				spawnRotation = Quaternion.Euler (0, 240, 0);
				Instantiate (hazard [x], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.3);

			}
		} else if (wavet == 7) {
			Vector3 spawnPosition = new Vector3 (0, spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.Euler (0, 180, 0);
			Instantiate (hazard [0], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (-spawnValues.x, spawnValues.y, spawnValues.z);
			spawnRotation = Quaternion.Euler (0, 160, 0);
			Instantiate (hazard [0], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, spawnValues.z);
			spawnRotation = Quaternion.Euler (0, 200, 0);
			Instantiate (hazard [0], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (0, spawnValues.y, -7);
			spawnRotation = Quaternion.Euler (0, 0, 0);
			Instantiate (hazard [0], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (-spawnValues.x, spawnValues.y, -7);
			spawnRotation = Quaternion.Euler (0, 20, 0);
			Instantiate (hazard [0], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, -7);
			spawnRotation = Quaternion.Euler (0, -20, 0);
			Instantiate (hazard [0], spawnPosition, spawnRotation);
			yield return new WaitForSeconds ((float)0.3);
			spawnPosition = new Vector3 (-spawnValues.x - 1, spawnValues.y, 4);
			spawnRotation = Quaternion.Euler (0, 90, 0);
			Instantiate (hazard [0], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, 4);
			spawnRotation = Quaternion.Euler (0, -90, 0);
			Instantiate (hazard [0], spawnPosition, spawnRotation);
			yield return new WaitForSeconds ((float)0.3);
			spawnPosition = new Vector3 (-4, spawnValues.y, spawnValues.z);
			spawnRotation = Quaternion.Euler (0, 170, 0);
			Instantiate (hazard [0], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (4, spawnValues.y, spawnValues.z);
			spawnRotation = Quaternion.Euler (0, 190, 0);
			Instantiate (hazard [0], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (4, spawnValues.y, -7);
			spawnRotation = Quaternion.Euler (0, 350, 0);
			Instantiate (hazard [0], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (-4, spawnValues.y, -7);
			spawnRotation = Quaternion.Euler (0, 10, 0);
			Instantiate (hazard [0], spawnPosition, spawnRotation);
		} else if (wavet == 8) {
			Vector3 spawnPosition = new Vector3 (0, spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.Euler (0, 180, 0);
			Instantiate (hazard [2], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (-spawnValues.x, spawnValues.y, spawnValues.z);
			spawnRotation = Quaternion.Euler (0, 160, 0);
			Instantiate (hazard [2], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, spawnValues.z);
			spawnRotation = Quaternion.Euler (0, 200, 0);
			Instantiate (hazard [2], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (0, spawnValues.y, -7);
			spawnRotation = Quaternion.Euler (0, 0, 0);
			Instantiate (hazard [2], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (-spawnValues.x, spawnValues.y, -7);
			spawnRotation = Quaternion.Euler (0, 20, 0);
			Instantiate (hazard [2], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, -7);
			spawnRotation = Quaternion.Euler (0, -20, 0);
			Instantiate (hazard [2], spawnPosition, spawnRotation);
			yield return new WaitForSeconds ((float)0.3);
			spawnPosition = new Vector3 (-spawnValues.x - 1, spawnValues.y, 4);
			spawnRotation = Quaternion.Euler (0, 90, 0);
			Instantiate (hazard [2], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, 4);
			spawnRotation = Quaternion.Euler (0, -90, 0);
			Instantiate (hazard [2], spawnPosition, spawnRotation);
			yield return new WaitForSeconds ((float)0.3);
			spawnPosition = new Vector3 (-4, spawnValues.y, spawnValues.z);
			spawnRotation = Quaternion.Euler (0, 170, 0);
			Instantiate (hazard [2], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (4, spawnValues.y, spawnValues.z);
			spawnRotation = Quaternion.Euler (0, 190, 0);
			Instantiate (hazard [2], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (4, spawnValues.y, -7);
			spawnRotation = Quaternion.Euler (0, 350, 0);
			Instantiate (hazard [2], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (-4, spawnValues.y, -7);
			spawnRotation = Quaternion.Euler (0, 10, 0);
			Instantiate (hazard [2], spawnPosition, spawnRotation);
		} else if (wavet == 9) {
			Vector3 spawnPosition = new Vector3 (-spawnValues.x, spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.Euler (0, Random.Range (100, 170), 0);
			for (int i = 0; i < 25; i++) {
				spawnRotation = Quaternion.Euler (0, Random.Range (110, 180), 0);
				int x = Random.Range (1, 4);
				if (x % 2 == 1)
					x = 0;
				else
					x = 2;
				Instantiate (hazard [x], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.3);
			}
			yield return new WaitForSeconds ((float)1.5);
			spawnPosition = new Vector3 (-6, spawnValues.y, -7);
			spawnRotation = Quaternion.Euler (0, 0, 0);
			Instantiate (hazard [1], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (-3, spawnValues.y, -7);
			spawnRotation = Quaternion.Euler (0, 0, 0);
			Instantiate (hazard [1], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (0, spawnValues.y, -7);
			spawnRotation = Quaternion.Euler (0, 0, 0);
			Instantiate (hazard [1], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (3, spawnValues.y, -7);
			spawnRotation = Quaternion.Euler (0, 0, 0);
			Instantiate (hazard [1], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (6, spawnValues.y, -7);
			spawnRotation = Quaternion.Euler (0, 0, 0);
			Instantiate (hazard [1], spawnPosition, spawnRotation);
			yield return new WaitForSeconds ((float)1.1);
		} else if (wavet == 10) {
			for (int i = -6; i <= 6; i += 3) {
				Vector3 spawnPosition = new Vector3 (i, spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.Euler (0, 180, 0);
				Instantiate (hazard [3], spawnPosition, spawnRotation);
			}
		} else if (wavet == 11) {
			for (int i = 0; i < 20; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.Euler (0, 180, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
				if (i == 10) {
					spawnPosition = new Vector3 (0, spawnValues.y, spawnValues.z);
					spawnRotation = Quaternion.Euler (0, 180, 0);
					Instantiate (hazard [4], spawnPosition, spawnRotation);
					yield return new WaitForSeconds ((float)1.1);
				}
			}	
		} else if (wavet == 12) {
			for (int i = 0; i < 20; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.Euler (0, 180, 0);
				Instantiate (hazard [5], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)1.0);
			}
		} else if (wavet == 13) {
			for (int i = 0; i < 21; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, -7); 
				Quaternion spawnRotation = Quaternion.Euler (0, 0, 0);
				Instantiate (hazard [0], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.5);
				if (i % 3 == 0) {
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					spawnRotation = Quaternion.Euler (0, 180, 0);
					Instantiate (hazard [5], spawnPosition, spawnRotation);
					yield return new WaitForSeconds ((float)1.1);
				}
			}
		} else if (wavet == 14) {	
			Vector3 spawnPosition = new Vector3 (-3, spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.Euler (0, 180, 0);
			Instantiate (hazard [6], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (3, spawnValues.y, spawnValues.z);
			spawnRotation = Quaternion.Euler (0, 180, 0);
			Instantiate (hazard [6], spawnPosition, spawnRotation);
			yield return new WaitForSeconds ((float)0.5);
			for (int i = 0; i < 40; i++) {
				spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, Random.Range (-2, spawnValues.z));
				spawnRotation = Quaternion.Euler (0, 270, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.3);
			}
		} else if (wavet == 15) {
			Vector3 spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, 10);
			Quaternion spawnRotation = Quaternion.Euler (0, 270, 0);
			Instantiate (hazard [6], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (-spawnValues.x - 1, spawnValues.y, 2);
			spawnRotation = Quaternion.Euler (0, 90, 0);
			Instantiate (hazard [6], spawnPosition, spawnRotation);
			for (int i = 0; i < 10; i++) {
				spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				spawnRotation = Quaternion.Euler (0, 180, 0);
				Instantiate (hazard [5], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)1.0);
			}
		} else if (wavet == 16) {
			for (int i = 0; i < 40; i++) {
				Vector3 spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, Random.Range (-5, spawnValues.z));
				Quaternion spawnRotation = Quaternion.Euler (0, 270, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.4);
				if (i % 10 == 0) {
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					spawnRotation = Quaternion.Euler (0, 180, 0);
					Instantiate (hazard [4], spawnPosition, spawnRotation);
					yield return new WaitForSeconds ((float)0.4);
				}
				spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, Random.Range (-5, spawnValues.z));
				spawnRotation = Quaternion.Euler (0, 270, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.4);
			}
		} else if (wavet == 18) {
			for (int i = 0; i < 60; i++) {
				Vector3 spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, Random.Range (-4, spawnValues.z));
				Quaternion spawnRotation = Quaternion.Euler (0, 270, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.3);
				if (i == 10) {
					spawnPosition = new Vector3 (-spawnValues.x - 1, spawnValues.y, spawnValues.z);
					spawnRotation = Quaternion.Euler (0, 135, 0);
					Instantiate (hazard [3], spawnPosition, spawnRotation);
					yield return new WaitForSeconds ((float)0.4);
				}
				if (i == 20) {
					spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, spawnValues.z);
					spawnRotation = Quaternion.Euler (0, 225, 0);
					Instantiate (hazard [3], spawnPosition, spawnRotation);
					yield return new WaitForSeconds ((float)0.4);
				}
				if (i == 30) {
					spawnPosition = new Vector3 (-spawnValues.x - 1, spawnValues.y, -7);
					spawnRotation = Quaternion.Euler (0, 45, 0);
					Instantiate (hazard [3], spawnPosition, spawnRotation);
					yield return new WaitForSeconds ((float)0.4);
				}
				if (i == 40) {
					spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, -7);
					spawnRotation = Quaternion.Euler (0, 315, 0);
					Instantiate (hazard [3], spawnPosition, spawnRotation);
					yield return new WaitForSeconds ((float)0.4);
				}
				if (i == 50) {
					spawnPosition = new Vector3 (-spawnValues.x - 1, spawnValues.y, 10);
					spawnRotation = Quaternion.Euler (0, 90, 0);
					Instantiate (hazard [3], spawnPosition, spawnRotation);
					spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, 10);
					spawnRotation = Quaternion.Euler (0, 270, 0);
					Instantiate (hazard [3], spawnPosition, spawnRotation);
					yield return new WaitForSeconds ((float)0.4);
				}
				spawnPosition = new Vector3 (-spawnValues.x - 1, spawnValues.y, Random.Range (-4, spawnValues.z));
				spawnRotation = Quaternion.Euler (0, 90, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.3);
			}
		} else if (wavet == 19) {
			for (int i = 0; i < 7; i++) {
				Vector3 spawnPosition = new Vector3 (0, spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.Euler (0, 180, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.2);
				spawnPosition = new Vector3 (spawnValues.x - 2, spawnValues.y, spawnValues.z);
				spawnRotation = Quaternion.Euler (0, 200, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.2);
				spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, spawnValues.z);
				spawnRotation = Quaternion.Euler (0, 225, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.2);
				spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, 13);
				spawnRotation = Quaternion.Euler (0, 235, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.2);
				spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, 10);
				spawnRotation = Quaternion.Euler (0, 250, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.2);
				spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, 4);
				spawnRotation = Quaternion.Euler (0, 270, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.2);
				spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, 0);
				spawnRotation = Quaternion.Euler (0, 290, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.2);
				spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, -3);
				spawnRotation = Quaternion.Euler (0, 300, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.2);
				spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, -7);
				spawnRotation = Quaternion.Euler (0, 315, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.2);
				spawnPosition = new Vector3 (spawnValues.x - 2, spawnValues.y, -7);
				spawnRotation = Quaternion.Euler (0, 330, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.2);
				spawnPosition = new Vector3 (0, spawnValues.y, -7);
				spawnRotation = Quaternion.Euler (0, 0, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.2);
				spawnPosition = new Vector3 (-4, spawnValues.y, -7);
				spawnRotation = Quaternion.Euler (0, 30, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.2);
				spawnPosition = new Vector3 (-spawnValues.x, spawnValues.y, -7);
				spawnRotation = Quaternion.Euler (0, 45, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.2);
				spawnPosition = new Vector3 (-spawnValues.x - 1, spawnValues.y, -3);
				spawnRotation = Quaternion.Euler (0, 60, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.2);
				spawnPosition = new Vector3 (-spawnValues.x - 1, spawnValues.y, 0);
				spawnRotation = Quaternion.Euler (0, 75, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.2);
				spawnPosition = new Vector3 (-spawnValues.x - 1, spawnValues.y, 4);
				spawnRotation = Quaternion.Euler (0, 90, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.2);
				spawnPosition = new Vector3 (-spawnValues.x - 1, spawnValues.y, 10);
				spawnRotation = Quaternion.Euler (0, 110, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.2);
				spawnPosition = new Vector3 (-spawnValues.x - 1, spawnValues.y, 13);
				spawnRotation = Quaternion.Euler (0, 125, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.2);
				spawnPosition = new Vector3 (-spawnValues.x - 1, spawnValues.y, spawnValues.z);
				spawnRotation = Quaternion.Euler (0, 135, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.2);
				spawnPosition = new Vector3 (-spawnValues.x + 2, spawnValues.y, spawnValues.z);
				spawnRotation = Quaternion.Euler (0, 160, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.2);
			}
		} else if (wavet == 20) {
			Vector3 spawnPosition = new Vector3 (-spawnValues.x - 1, spawnValues.y, -4);
			Quaternion spawnRotation = Quaternion.Euler (0, 90, 0);
			Instantiate (hazard [6], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, 3);
			spawnRotation = Quaternion.Euler (0, 90, 0);
			Instantiate (hazard [6], spawnPosition, spawnRotation);
			for (int i = 0; i < 54; i++) {
				spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, -7);
				spawnRotation = Quaternion.Euler (0, 0, 0);
				Instantiate (hazard [2], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.5);
				if (i % 3 == 0) {
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					spawnRotation = Quaternion.Euler (0, 180, 0);
					Instantiate (hazard [4], spawnPosition, spawnRotation);
					yield return new WaitForSeconds ((float)1.0);
				}

				if (i % 20 == 0) {
					spawnPosition = new Vector3 (-spawnValues.x - 1, spawnValues.y, -4);
					spawnRotation = Quaternion.Euler (0, 90, 0);
					Instantiate (hazard [6], spawnPosition, spawnRotation);
					spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, 3);
					spawnRotation = Quaternion.Euler (0, 90, 0);
					Instantiate (hazard [6], spawnPosition, spawnRotation);
				}
			}
			yield return new WaitForSeconds ((float)5.0);
		} else if (wavet == 21) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.Euler (0, 180, 0);
			for (int i = 0; i < 35; i++) {
				int x = Random.Range (1, 4);
				if (x == 1) {
					spawnRotation = Quaternion.Euler (0, 180, 0);
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					Instantiate (hazard [5], spawnPosition, spawnRotation);
					yield return new WaitForSeconds ((float)0.2);
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					Instantiate (hazard [7], spawnPosition, spawnRotation);
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					Instantiate (hazard [7], spawnPosition, spawnRotation);
					yield return new WaitForSeconds ((float)0.9);
				}
				if (x == 2) {
					spawnRotation = Quaternion.Euler (0, 0, 0);
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, -7);
					Instantiate (hazard [5], spawnPosition, spawnRotation);
					yield return new WaitForSeconds ((float)0.2);
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, -7);
					Instantiate (hazard [7], spawnPosition, spawnRotation);
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, -7);
					Instantiate (hazard [7], spawnPosition, spawnRotation);
					yield return new WaitForSeconds ((float)0.9);
				}
				if (x == 3) {
					spawnRotation = Quaternion.Euler (0, 90, 0);
					spawnPosition = new Vector3 (-spawnValues.x - 1, spawnValues.y, Random.Range (-7, spawnValues.z));
					Instantiate (hazard [5], spawnPosition, spawnRotation);
					yield return new WaitForSeconds ((float)0.2);
					spawnPosition = new Vector3 (-spawnValues.x - 1, spawnValues.y, Random.Range (-7, spawnValues.z));
					Instantiate (hazard [7], spawnPosition, spawnRotation);
					spawnPosition = new Vector3 (-spawnValues.x - 1, spawnValues.y, Random.Range (-7, spawnValues.z));
					Instantiate (hazard [7], spawnPosition, spawnRotation);
					yield return new WaitForSeconds ((float)0.9);
				}
				if (x == 4) {
					spawnRotation = Quaternion.Euler (0, 270, 0);
					spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, Random.Range (-7, spawnValues.z));
					Instantiate (hazard [5], spawnPosition, spawnRotation);
					yield return new WaitForSeconds ((float)0.2);
					spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, Random.Range (-7, spawnValues.z));
					Instantiate (hazard [7], spawnPosition, spawnRotation);
					spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, Random.Range (-7, spawnValues.z));
					Instantiate (hazard [7], spawnPosition, spawnRotation);
					yield return new WaitForSeconds ((float)0.9);
				}
			}
		} else if (wavet == 17) {
			for (int i = 0; i < 60; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.Euler (0, 180, 0);
				Instantiate (hazard [7], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.1);
			}
		} else if (wavet == 22) {
			Vector3 spawnPosition = new Vector3 (0, spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.Euler (0, 180, 0);
			Instantiate (hazard [7], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (-spawnValues.x, spawnValues.y, spawnValues.z);
			spawnRotation = Quaternion.Euler (0, 160, 0);
			Instantiate (hazard [7], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, spawnValues.z);
			spawnRotation = Quaternion.Euler (0, 200, 0);
			Instantiate (hazard [7], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (0, spawnValues.y, -7);
			spawnRotation = Quaternion.Euler (0, 0, 0);
			Instantiate (hazard [7], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (-spawnValues.x, spawnValues.y, -7);
			spawnRotation = Quaternion.Euler (0, 20, 0);
			Instantiate (hazard [7], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, -7);
			spawnRotation = Quaternion.Euler (0, -20, 0);
			Instantiate (hazard [7], spawnPosition, spawnRotation);
			yield return new WaitForSeconds ((float)0.3);
			spawnPosition = new Vector3 (-spawnValues.x - 1, spawnValues.y, 4);
			spawnRotation = Quaternion.Euler (0, 90, 0);
			Instantiate (hazard [7], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, 4);
			spawnRotation = Quaternion.Euler (0, -90, 0);
			Instantiate (hazard [7], spawnPosition, spawnRotation);
			yield return new WaitForSeconds ((float)0.3);
			spawnPosition = new Vector3 (-4, spawnValues.y, spawnValues.z);
			spawnRotation = Quaternion.Euler (0, 170, 0);
			Instantiate (hazard [7], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (4, spawnValues.y, spawnValues.z);
			spawnRotation = Quaternion.Euler (0, 190, 0);
			Instantiate (hazard [7], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (4, spawnValues.y, -7);
			spawnRotation = Quaternion.Euler (0, 350, 0);
			Instantiate (hazard [7], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (-4, spawnValues.y, -7);
			spawnRotation = Quaternion.Euler (0, 10, 0);
			Instantiate (hazard [7], spawnPosition, spawnRotation);
			yield return new WaitForSeconds ((float)0.9);
			spawnPosition = new Vector3 (-spawnValues.x - 1, spawnValues.y, 7);
			spawnRotation = Quaternion.Euler (0, 90, 0);
			Instantiate (hazard [4], spawnPosition, spawnRotation);
			yield return new WaitForSeconds ((float)0.9);
			for (int p = 12; p >= -4; p -= 2) {
				spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, p);
				spawnRotation = Quaternion.Euler (0, 270, 0);
				Instantiate (hazard [7], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.3);
			}
		} else if (wavet == 23) {
			for (int i = 0; i <= 30; i++) {
				Vector3 spawnPosition = new Vector3 (-spawnValues.x - 1, spawnValues.y, Random.Range (-4, 13));
				Quaternion spawnRotation = Quaternion.Euler (0, 90, 0);
				Instantiate (hazard [5], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)1.0);
				spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, Random.Range (-4, 13));
				spawnRotation = Quaternion.Euler (0, 270, 0);
				Instantiate (hazard [5], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)1.0);
				if (i % 3 == 0) {
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					spawnRotation = Quaternion.Euler (0, 180, 0);
					Instantiate (hazard [8], spawnPosition, spawnRotation);
				}

			}
		} else if (wavet == 24) {
			for (int i = 0; i <= 10; i++) {
				Vector3 spawnPosition = new Vector3 (-spawnValues.x - 1, spawnValues.y, i - 4);
				Quaternion spawnRotation = Quaternion.Euler (0, 90, 0);
				Instantiate (hazard [6], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.5);

				for (int w = 0; w <= 10; w++) {
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					spawnRotation = Quaternion.Euler (0, 180, 0);
					Instantiate (hazard [7], spawnPosition, spawnRotation);
					yield return new WaitForSeconds ((float)0.2);
				}
			}
			yield return new WaitForSeconds ((float)6.2);
		} else if (wavet == 1) {
			StartCoroutine(Bossfight ());
			yield return new WaitUntil (()=>bossdone2);
			Vector3 spawnPosition = new Vector3 (0, spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.Euler (0, 180, 0);
			//Instantiate (hazard [x], spawnPosition, spawnRotation);
		}

		else  
		for (int i = 0; i < hazardCount; i++) {
			int x = Random.Range (0, hazard.Length);
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.Euler (0, 180, 0);
			Instantiate (hazard [x], spawnPosition, spawnRotation);
			yield return new WaitForSeconds (spawnWait);
		}
		
		yield return new WaitForSeconds (waveWait);
		wavedone = true;
	}


	IEnumerator Bossfight ()
	{
		int pola = 0;
		Vector3 hore = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
		Quaternion hore2 = Quaternion.Euler (0, 180, 0);
		Instantiate (powerup [0], hore, hore2);
		Vector3 spawnPosition = new Vector3 (0, spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.Euler (0, 180, 0);
		Instantiate (powerup[1], spawnPosition, spawnRotation);
		yield return new WaitForSeconds ((float)0.3);
		while (!bossdone) {
			if (pola % 3 == 0) {
				for (int i = 0; i < 60; i++) {
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					spawnRotation = Quaternion.Euler (0, 180, 0);
					Instantiate (hazard [7], spawnPosition, spawnRotation);
					yield return new WaitForSeconds ((float)0.1);
					if (i % 10 == 0) {
						spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, Random.Range (-4, 13));
						spawnRotation = Quaternion.Euler (0, 270, 0);
						Instantiate (hazard [8], spawnPosition, spawnRotation);
						yield return new WaitForSeconds ((float)0.1);
					}
				}
			}

			if (pola % 3 == 1) {
				for (int i = 0; i < 20; i++) {
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					spawnRotation = Quaternion.Euler (0, 180, 0);
					Instantiate (hazard [5], spawnPosition, spawnRotation);
					yield return new WaitForSeconds ((float)0.85);

				}
			}

			if (pola % 3 == 2) {
				for (int i = 0; i < 7; i++) {
					if (i % 2 == 0) {
						spawnPosition = new Vector3 (spawnValues.x + 1, spawnValues.y, Random.Range (-4, 13));
						spawnRotation = Quaternion.Euler (0, 270, 0);
						Instantiate (hazard [4], spawnPosition, spawnRotation);
						yield return new WaitForSeconds ((float)0.1);
					}
					else 
					{
						spawnPosition = new Vector3 (-spawnValues.x - 1, spawnValues.y, Random.Range (-4, 13));
						spawnRotation = Quaternion.Euler (0, 90, 0);
						Instantiate (hazard [4], spawnPosition, spawnRotation);
						yield return new WaitForSeconds ((float)0.1);
					}
					yield return new WaitForSeconds ((float)1.5);
				}
			}
			pola++;
			yield return new WaitForSeconds (waveWait);
			yield return new WaitForSeconds (waveWait);
		}
		Debug.Log ("bossdone");
		bossdone2 = true;

	}



}






