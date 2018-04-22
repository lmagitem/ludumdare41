using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {

	public int colorPower = 1;
	public Sprite color1;
	public Sprite color2;
	public Sprite color3;

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
		bool activate = gameObject.GetComponent<Car2DController>().desactiverPower;
		if (activate == false) {
			colorPower = 3;
		}
	}

	void FixedUpdate () {
		if (colorPower == 3) {
			GetComponent<SpriteRenderer> ().sprite = color3;
		}
	}
}
