using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutUp : MonoBehaviour {

	// the whole point of the game is to rid yourself of the annoying crying sound
	// it's really stupid to have this 'mute' button.
	//  but my god - I couldn't stand it anymore.

	bool onOff = true;

	public void MuteItAll () {
		onOff = !onOff;
		// I can never figure out how to get the sprite swap in the inspector to switch sprites
		// I kind of don't care though - you shouldn't be hitting the button 
		if (onOff)
			AudioListener.volume = 0f;
		else
			AudioListener.volume = 1f;
	}


	// I should just delete this code
	// but leave the button
	// that would be hysterical.
}
