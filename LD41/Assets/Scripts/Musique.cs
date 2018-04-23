using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musique : MonoBehaviour {

	private static bool created = false;

	void Awake(){

		if (!created)
		{
			DontDestroyOnLoad (gameObject);
			created = true;
		}
		//DontDestroyOnLoad (transform.gameObject);		
	}
}
