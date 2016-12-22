using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {
	public GUIText ScoreFinal;
	public GUIText WaveFinal;
	void Awake(){
		ScoreFinal.text = "Your Score: " + GameController.score;
		WaveFinal.text = "Your last wave is " + GameController.wavet;
	}
}
