using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {
	public GUIText ScoreFinal;
	
	void Awake(){
		ScoreFinal.text = "Score: " + GameController.score;
	}
}
