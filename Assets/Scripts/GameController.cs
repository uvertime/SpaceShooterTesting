﻿using UnityEngine;
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
	private  int score;
	private  int wavet;
	private  bool wavedone;
	public int lives;
	public int bombs;
	public GUIText WaveText;
	public GUIText restartText;
	public GUIText gameOverText;
	private bool gameOver;
	private bool restart;
	void Start(){
		lives = 2;
		bombs = 2;
		gameOver = false;
		restart = false;
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
		SceneManager.LoadScene ("Game Over Dewi");
		DontDestroyOnLoad (transform.gameObject);
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



		if (wavet == 1) 
		{
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
		}
		else if (wavet == 12){
			for (int i = 0; i < 20; i++) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.Euler (0, 180, 0);
			Instantiate (hazard [5], spawnPosition, spawnRotation);
			yield return new WaitForSeconds ((float)1.0);
		}
		}

		else if (wavet == 13){
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
		}

		else if (wavet ==14)
		{	
			Vector3 spawnPosition = new Vector3 (-3, spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.Euler (0, 180, 0);
			Instantiate (hazard [6], spawnPosition, spawnRotation);
			spawnPosition = new Vector3 (3, spawnValues.y, spawnValues.z);
			spawnRotation = Quaternion.Euler (0, 180, 0);
			Instantiate (hazard [6], spawnPosition, spawnRotation);
			yield return new WaitForSeconds ((float)0.5);
			for (int i = 0; i < 40; i++) {
			spawnPosition = new Vector3 (spawnValues.x+1, spawnValues.y, Random.Range (-2, spawnValues.z));
			spawnRotation = Quaternion.Euler (0, 270, 0);
			Instantiate (hazard [2], spawnPosition, spawnRotation);
			yield return new WaitForSeconds ((float)0.3);
		}
		}

		else if (wavet == 15)
		{
			Vector3 spawnPosition = new Vector3 (spawnValues.x+1, spawnValues.y, 10);
		Quaternion spawnRotation = Quaternion.Euler (0, 270, 0);
		Instantiate (hazard [6], spawnPosition, spawnRotation);
		spawnPosition = new Vector3 (-spawnValues.x-1, spawnValues.y, 2);
		spawnRotation = Quaternion.Euler (0, 90, 0);
		Instantiate (hazard [6], spawnPosition, spawnRotation);
		for (int i = 0; i < 10; i++) {
			spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			spawnRotation = Quaternion.Euler (0, 180, 0);
			Instantiate (hazard [5], spawnPosition, spawnRotation);
			yield return new WaitForSeconds ((float)1.0);
		}
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




}






