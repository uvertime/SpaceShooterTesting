using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public float speed;
	void Start ()
	{
		GetComponent<Rigidbody> ().velocity = GetComponent<Transform>().forward * speed;
	}
		
}
