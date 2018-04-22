using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {

	public int colorPower = 1;
	public Sprite color1;
	public Sprite color2;

	// Use this for initialization
	void Awake () 
	{
		if (colorPower == 1)
		{
		GetComponent<SpriteRenderer> ().sprite = color1;
		}

		if (colorPower == 2) 
		{
			GetComponent<SpriteRenderer> ().sprite = color2;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
