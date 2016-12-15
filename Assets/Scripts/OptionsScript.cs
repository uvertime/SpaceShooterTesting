using UnityEngine;
using System.Collections;

public class OptionsScript : MonoBehaviour {

public void ChangeToOptions (string sceneToChangeTo) {
		Application.LoadLevel (sceneToChangeTo);
	}
}
