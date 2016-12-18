using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {
	public AudioClip powersound;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			AudioSource.PlayClipAtPoint (powersound, transform.position);
			Destroy (gameObject);
		}

	}

}
