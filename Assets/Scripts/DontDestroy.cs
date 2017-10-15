using UnityEngine;

public class DontDestroy : MonoBehaviour {


	void Awake ()
	{
		//if (!gameOver)
			DontDestroyOnLoad (gameObject);
	}
}
