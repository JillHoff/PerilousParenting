using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragStart : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public static GameObject itemBeingDraged;
	Vector3 startPosition;
	Transform startParent;

	// same as the drag and drop for the play levels - except this time it is for the 
	// start screen - good way to tell the players what they're gonna have to do
	// to play the game - right?

	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDraged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
	}




	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}




	public void OnEndDrag (PointerEventData eventData)
	{
		itemBeingDraged = null;
		if (transform.parent == startParent)
			transform.position = startPosition;
	
	}
}
