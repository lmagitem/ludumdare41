using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {

	public int colorPower = 1;
	public Sprite color1;
	public Sprite color2;
	public Sprite color3;


	public bool desactiverPower = false;
	public float tempsDesacPower = 2f;

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
