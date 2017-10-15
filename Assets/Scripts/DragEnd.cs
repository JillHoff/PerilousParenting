using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DragEnd : MonoBehaviour, IDropHandler {

	// drag the word 'start' over to it's slot to start the game.

	Scene scene;

	void Start () {
		 scene = SceneManager.GetActiveScene ();
	}

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

			DragStart.itemBeingDraged.transform.SetParent (transform); 
			SceneManager.LoadScene (scene.buildIndex + 1);

		}
	}
}
