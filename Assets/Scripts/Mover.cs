using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public float speed;
	public bool stop;
	private Transform MyPosition;
	void Start ()
	{
		GetComponent<Rigidbody> ().velocity = GetComponent<Transform>().forward * speed;
		MyPosition = GetComponent<Transform> ();
	}
	void update(){
		if (stop && MyPosition.position.z <= 13)
			GetComponent<Rigidbody> ().velocity = GetComponent<Transform>().forward * 0;
	}
		
}
