using UnityEngine;
using System.Collections;

public class MoverRadiostrontium : MonoBehaviour {
	public float speed;
	void Start ()
	{
		GetComponent<Rigidbody> ().velocity = GetComponent<Transform>().forward * speed;
		//if () {
		//	speed = 0;
		//}
	}
		
}
