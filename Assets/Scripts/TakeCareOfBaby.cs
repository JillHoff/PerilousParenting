using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TakeCareOfBaby : MonoBehaviour, IDropHandler
{
	// this is the core of the game right here.  You might think it should be called
	// something like game control or something.
	// I have an empty game object called Game Control, but all it does is call the 
	// quit game script - which is also missnamed.

	public Animator anim;
	public Image cdPacifier;
	public Image cdBottle;
	public Image cdDiaper;
	// the cd stands for cool down - not a good name - I keep forgetting what it ment
	// hence this comment

	public GameObject bottle;
	public GameObject pacifier;
	public GameObject diaper;
	public GameObject musicBox;

	public GameObject cryMeter;
	public bool crying = true;
	public int cryingDuration = 0;

	public Canvas youLoseScene;
	public Canvas youWinScene;

	Scene scene;

	void Start ()
	{
		// this script is attached to each baby
		// First thing to do: Make the baby cry!  HA!
		anim.SetBool ("isCrying", true);

		StartCoroutine ("IncreaseCryMeter");  // the dumb red bar on their cribs that I hate
		scene = SceneManager.GetActiveScene ();
		GetComponent<AudioSource> ().Play ();  
		Time.timeScale = 1;  // this is to counteract the 'pause' (see below)
	}

	void Update ()
	{
		
		if (cryingDuration >= 10)
			StartCoroutine ("Explode");
			//  if you let the baby cry too long - bad things happen.
			// I say explode - but really - they just turn into flowers - it's metaphorical
		else {
			if (Time.timeSinceLevelLoad > ((10 * scene.buildIndex) + 15)) {
				
				youWinScene.GetComponent<Canvas> ().enabled = true;
				Time.timeScale = 0;  //  a super cool way to pause the game, stops all the timers
									// but all the buttons and the sounds still work.  
			}
		}
			

	}


	public GameObject item {
		// this is a construct. or a struct. I'm not sure - but either way
		// it's a variable with depth.  a variable with a 'get' 
		//  it's just a way to check if the baby has a 'child' (that sounds so wrong)
		get {
			if (transform.childCount > 0)
				return transform.GetChild (0).gameObject;
			else
				return null;
		}
	}

	public void OnDrop (PointerEventData eventData)
	{
		if (!item && eventData.pointerDrag.tag != "MusicBox") {  
			//make sure this baby doesn't already have a droped item on it
			// and make sure the item isn't the music box
			//  you can't drop a music box on the baby
			// that's not how a music box works.
			// you should know that.

			DragnDrop.itemBeingDraged.transform.SetParent (transform);  
			// now the baby has an item that is appropreate for a baby to have

			if (item.tag == "Bottle") {

				StartCoroutine ("StopCrying", 5);
				cdBottle.GetComponent<Image> ().enabled = true;
				cdBottle.GetComponent<Animator> ().enabled = true;
				// the cd stands for cool down.  Did you forget?  I did.
			}
			if (item.tag == "Diaper") {

				StartCoroutine ("StopCrying", 7);
				cdDiaper.GetComponent<Image> ().enabled = true;
				cdDiaper.GetComponent<Animator> ().enabled = true;
				// anyway - all three of these call the stop crying 
				// and turn on the gray circle/time animation thingy
			}
			if (item.tag == "Pacifier") {

				StartCoroutine ("StopCrying", 3);
				cdPacifier.GetComponent<Image> ().enabled = true;
				cdPacifier.GetComponent<Animator> ().enabled = true;
				// gray circle/time animation - yeah, I meant cool down animation
			}

		}
	}

	IEnumerator StopCrying (float time)
	{
		crying = false; // finally
		GetComponent<AudioSource> ().mute = true;  // shup up the crying already
		StartCoroutine ("DecreaseCryMeter"); // the red bar I hate
		anim.SetBool ("isCrying", false); // run the cute happy baby animation
		yield return new WaitForSeconds (time);  //  take a breath
		anim.SetBool ("isCrying", true);  // back to the not so cute animation
		if (item != null)
			Destroy (item);//  kill the child of the baby - so sad
		crying = true;// even sadder
		GetComponent<AudioSource> ().mute = false; // and the wailing starts all over again.
		StartCoroutine ("IncreaseCryMeter");// the red bar I hate
	}

	IEnumerator IncreaseCryMeter ()
	{
		// I hate this thing - I just don't think it's neccessary - but the playtesters are always right
		while (crying) {
			// for every second the baby is crying - make more red in the bar
			if (cryingDuration < 10)
				cryingDuration++;
			cryMeter.GetComponent<CryMeter> ().SetCryMeter (cryingDuration);
			yield return new WaitForSeconds (1);				
		}


	}

	IEnumerator DecreaseCryMeter ()
	{// whatever.
		while (!crying) {
			// for every second the baby is NOT crying - make less red in the bar
			if (cryingDuration > 0)
				cryingDuration--;
			cryMeter.GetComponent<CryMeter> ().SetCryMeter (cryingDuration);
			yield return new WaitForSeconds (1);
		}

	}

	IEnumerator Explode ()
	{
		//  Why you use that word? I don't think it means what you think it means.
		anim.SetBool ("explode", true);
		// show the pretty flower animation in place of the baby
		// doesn't mean that the baby is dead
		// really
		yield return new WaitForSeconds (3);
		youLoseScene.GetComponent<Canvas> ().enabled = true;
		//  you are a loser - here is a screen to tell you so


	}
}
