﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject[] hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GUIText scoreText;
	private  int score;
	private  int wavet;
	private  bool wavedone; 
	public GUIText WaveText;
	public GUIText restartText;
	public GUIText gameOverText;
	private bool gameOver;
	private bool restart;
	void Start(){
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		wavet = 1;
		UpdateWave ();
		StartCoroutine (SpawnWaves ());
	}

	void Update(){
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
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
	}

	void UpdateWave()
	{
		WaveText.text = "Wave " + wavet;
	}


	// mulai dari sini adalah desain level


	IEnumerator levelcount()
	{

		if (wavet == 1) {
			int y = Random.Range (5, 20);
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
				Vector3 spawnPosition = new Vector3 (-5+x, spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.Euler (0, 180, 0);
				Instantiate (hazard [0], spawnPosition, spawnRotation);
				x = Random.Range (-1, 1);
				spawnPosition = new Vector3 (5+x, spawnValues.y, spawnValues.z);
				spawnRotation = Quaternion.Euler (0, 180, 0);
				Instantiate (hazard [0], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.1);
				x = Random.Range (-1, 1);
				spawnPosition = new Vector3 (-3+x, spawnValues.y, spawnValues.z);
				spawnRotation = Quaternion.Euler (0, 180, 0);
				Instantiate (hazard [0], spawnPosition, spawnRotation);
				x = Random.Range (-1, 1);
				spawnPosition = new Vector3 (3+x, spawnValues.y, spawnValues.z);
				spawnRotation = Quaternion.Euler (0, 180, 0);
				Instantiate (hazard [0], spawnPosition, spawnRotation);
				yield return new WaitForSeconds ((float)0.1);
				x = Random.Range (-2, 2);
				spawnPosition = new Vector3 (0+x, spawnValues.y, spawnValues.z);
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
		}

		else if (wavet == 4) {
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
		}
			
		/*else  
		for (int i = 0; i < hazardCount; i++) {
			int x = Random.Range (0, hazard.Length);
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.Euler (0, 180, 0);
			Instantiate (hazard [x], spawnPosition, spawnRotation);
			yield return new WaitForSeconds (spawnWait);
		}*/
		
		yield return new WaitForSeconds (waveWait);
		wavedone = true;
	}






}
