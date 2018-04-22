using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {

	public int colorPower = 1;
	public Sprite color1;
	public Sprite color2;
	public Sprite color4;
	private int originColor;


	public bool desactiverPower = false;
	public float tempsDesacPower = 2f;

	void Start()
	{
		int originColor = colorPower;
	}
	void Awake () 
	{
		if (colorPower == 1)
		{
		GetComponent<SpriteRenderer> ().sprite = color1;
		originColor = 1;
		}

		if (colorPower == 2) 
		{
			GetComponent<SpriteRenderer> ().sprite = color2;
			originColor = 2;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (colorPower == 4) 
		{
			GetComponent<SpriteRenderer> ().sprite = color4;
		}

	}

	void FixedUpdate () {

	}
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player") && desactiverPower==false) {
			desactiverPower = true;
			colorPower = 4;
			StartCoroutine ("desactivationPower");
		}
	}
	IEnumerator desactivationPower()
	{
		yield return new WaitForSeconds (tempsDesacPower);
		colorPower = originColor;
		print ("active");
		if (originColor == 1)
		{
			GetComponent<SpriteRenderer> ().sprite = color1;
			originColor = 1;
		}

		if (originColor == 2) 
		{
			GetComponent<SpriteRenderer> ().sprite = color2;
			originColor = 2;
		}
		desactiverPower = false;


	}
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			desactiverPower = true;
			StartCoroutine ("desactivationPower");

		}
	}
	IEnumerator desactivationPower()
	{
		yield return new WaitForSeconds (tempsDesacPower);
		desactiverPower = false;
	}
}
