using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsScriptColor : MonoBehaviour {

	public int colorDoor = 1;
	public Sprite color1;
	public Sprite color2;
	public Sprite color3;
	// Use this for initialization
	Collider2D intCollider;

	void start() {
		intCollider = GetComponent<Collider2D>();
	}

	void Awake () 
	{
		if (colorDoor == 1)
		{
			GetComponent<SpriteRenderer> ().sprite = color1;
			gameObject.layer = 9;
		}

		if (colorDoor == 2) 
		{
			GetComponent<SpriteRenderer> ().sprite = color2;
			gameObject.layer = 10;
		}
		if (colorDoor == 3) 
		{
			GetComponent<SpriteRenderer> ().sprite = color3;
			gameObject.layer = 11;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("test"))
		{
			intCollider.enabled = !intCollider.enabled;
			print ("collider" + intCollider.enabled);
		}
	}
}
