using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoE : MonoBehaviour {

	// Since the Music Box is not being droped on a baby - which is where all the drag and drop
	// code is, and since it would be affecting more than one baby at once
	// I decided to add a collision detector. 
	// The collider is only turned on after the music box is dropped,
	// so it doesn't get triggered by anything it is draged over on the way to it's final resting place.


	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Baby") 
		{
			other.gameObject.SendMessage ("StopCrying", 7f);
			StartCoroutine ("DestroyMusicBox");
		}
	}

	// destroy yourself after seven seconds, knowing you succeded in your one and only purpose

	IEnumerator DestroyMusicBox ()
	{
		yield return new WaitForSeconds (7);
		Destroy (this.gameObject);
	}

}
