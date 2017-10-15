using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragnDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	// I really have nothing to say here
	// I just copied this from somewhere else.
	// Drag and drop is one of those things that someone else figured out how to do a really
	// long time ago, there is no need to reinvent the wheel.
	// Having said that - I'm sure most of what I think of as clever problem solving
	// has been done before - I just didn't google long enough.
	// All thos assholes in Stack Overflow would like to thing there are no wheels.
	// They want everyone to figure out every thing from scratch, over and over again.
	// "That's how I learned!" "we didn't have any wheels in my day - we just carried everything
	// on our backs
	// up hill both ways
	// in five feet of snow."

	// Are we allowed to use that joke anymore - didn't it originate with Bill Cosby?

	// anyway - I have nothing to say here.

	public static GameObject itemBeingDraged;
	Vector3 startPosition;
	Transform startParent;



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
