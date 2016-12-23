using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public GameObject mainMenuHolder;
	public GameObject optionsMenuHolder;

	public Slider[] volumesliders;

	public void play(){
		SceneManager.LoadScene ("main");
	}

	public void exit(){
		Application.Quit ();
	}

	public void option(){
		SceneManager.LoadScene ("Option scene dewi");
	}

	public void tomenu(){
		SceneManager.LoadScene ("MainMenu dewi");
	}

	public void toinstructionscene(){
		SceneManager.LoadScene ("HowToPlay");
	}

	public void storyscene(){
		SceneManager.LoadScene ("Story");
	}

	public void tocreds(){
		SceneManager.LoadScene ("Credits");
	}
}