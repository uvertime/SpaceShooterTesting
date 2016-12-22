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
	void Update(){
		Debug.Log (MyPosition.position.z);
		if (stop && MyPosition.position.z <= 8)
			
			GetComponent<Rigidbody> ().velocity = GetComponent<Transform>().forward * speed * 0;

		}
		
}
