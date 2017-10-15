using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CryMeter : MonoBehaviour
{
	// I don't totally love how this works - I'd rather keep it all a mystery - like real babies
	// you don't really know when the thing you've done to make them happy is going to wear off, do you?

	public GameObject baby;

	public int currentValue = 0;

	Sprite meterSprite;

	public Sprite[] meterSprites;


	public void SetCryMeter (int value)
	{
		// I'm sure there is a much better way of doing this. 
		// In fact - I know know I could have done it with a slider. 
		// Just remove the 'knob' and set the background and fill colors,
		// then set the value of the slider to the baby cry amount.
		currentValue = value;
		switch (currentValue) {
		case 1:
			meterSprite = meterSprites[0];
			break;
	
		case 2:
			meterSprite = meterSprites[1];
			break;

		case 3:
			meterSprite = meterSprites[2];
			break;
			// I should really fix this...

		case 4:
			meterSprite = meterSprites[3];
			break;

		case 5:
			meterSprite = meterSprites[4];
			break;

		case 6:
			meterSprite = meterSprites[5];
			break;

		case 7:
			meterSprite = meterSprites[6];
			break;

		case 8:
			meterSprite = meterSprites[7];
			break;

		case 9:
			meterSprite = meterSprites[8];
			break;

		case 10:
			meterSprite = meterSprites[9];
			break;
		}
		// It's so inefficient.

		GetComponent<Image> ().sprite = meterSprite;
	}
}
