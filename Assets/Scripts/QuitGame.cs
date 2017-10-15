using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour {
	// a terribly mis-named script
	// it does have a function to quit
	// but it does so much more!

	Scene scene;

	void Start () {
		scene = SceneManager.GetActiveScene ();
	}
	
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape))
			Application.Quit();
		// this actually does nothing - except in the stand alone version - which I'm not even doing anymore
	}

	public void GetOut() {
		Application.Quit();
		// this only works in the mobile version - the web gl version wont let you quit
		// so annoying
	}

	public void YouWinButton() {
		SceneManager.LoadScene (scene.buildIndex + 1);
		// you get to go to the next sceen if you want to
	}

	public void YouLoseButton() {
		SceneManager.LoadScene (scene.buildIndex);
		// gotta repeat this level cause you suck
	}

	bool onOff = true;

	public void MuteItAll () {
		// why do I have this twice? - I have no idea - but I'm afraid to delete it.
		onOff = !onOff;
		if (onOff)
			AudioListener.volume = 1f;
		else
			AudioListener.volume = 0f;
	}

}
