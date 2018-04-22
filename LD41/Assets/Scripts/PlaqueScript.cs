using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaqueScript : MonoBehaviour {

	public int colorPlaque = 1;
	public Sprite color1;
	public Sprite color2;
	// Use this for initialization
	void Awake () 
	{
		if (colorPlaque == 1)
		{
			GetComponent<SpriteRenderer> ().sprite = color1;
		}

		if (colorPlaque == 2) 
		{
			GetComponent<SpriteRenderer> ().sprite = color2;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
