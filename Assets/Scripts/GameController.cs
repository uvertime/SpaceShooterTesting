using UnityEngine;
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
		

		if(wavet%3==1) 
		for (int i = 0; i < hazardCount; i++) {
			int x = Random.Range (0, hazard.Length);
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.Euler (0, 180, 0);
			Instantiate (hazard [x], spawnPosition, spawnRotation);
			yield return new WaitForSeconds (spawnWait);
		}
		
		else if(wavet%3==2)
			for (int i = 0; i < 15; i++) {
				//int x = Random.Range (0, hazard.Length);
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.Euler (0, 180, 0);
				Instantiate (hazard [0], spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
		
		else if(wavet%3==0) 
			for (int i = 0; i < hazardCount; i++) {
				//int x = Random.Range (0, hazard.Length);
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.Euler (0, 180, 0);
				Instantiate (hazard [1], spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
		
		yield return new WaitForSeconds (waveWait);
		wavedone = true;
	}






}
