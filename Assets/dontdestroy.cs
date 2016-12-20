using UnityEngine;
using System.Collections;

public class dontdestroy : MonoBehaviour {
	public GameObject score;
	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}

}
