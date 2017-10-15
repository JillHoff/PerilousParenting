using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndCoolDown : MonoBehaviour {

	// this is attached to the cool down gray/time circle thingy
	// at the end of the animation it calls this script to reset itself
	// and to create a new dragable item ontop of itself.
	// that is an awful lot of stuff to do in just a few lines of code.

	public GameObject newChild;

	public void ResetCoolDown () {
		GetComponent<Image> ().enabled = false;
		GetComponent<Animator> ().Play ("", 0, 0);
		GetComponent<Animator> ().enabled = false;
		Instantiate (newChild, GetComponentInParent<Transform> ());

	}

}