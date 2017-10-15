using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DropMusicBox : MonoBehaviour, IDropHandler
{
	// had to repeat a lot of the stuff I did for the baby for the music box - 
	// cause they're getting dropped on the floor - or whatever
	// what are they dropped on?  It that a table? 

	public Image cdMusicBox;


	public GameObject item {
		get {
			if (transform.childCount > 0)
				return transform.GetChild (0).gameObject;
			else
				return null;
		}
	}

	public void OnDrop (PointerEventData eventData)
	{
		if (!item) {  
			if (eventData.pointerDrag.tag == "MusicBox") {
				// this is all the same as the items in the Take Car of Baby script 
				// except for the lat line - that is where the collider is turned on 
				// the more babies hit by the collider the better.
				// well, not literally
				// like hit by sound waves or whatever.
				DragnDrop.itemBeingDraged.transform.SetParent (transform);
				cdMusicBox.GetComponent<Image> ().enabled = true;
				cdMusicBox.GetComponent<Animator> ().enabled = true;
				item.GetComponent<CircleCollider2D> ().enabled = true;
			}
		}
	}




}
