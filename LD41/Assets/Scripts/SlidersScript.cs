using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidersScript : MonoBehaviour {

    public int player = 0;

	// Use this for initialization
	void Start () {
        char[] temp = name.ToCharArray();
        player = int.Parse(temp[12].ToString());

        GameObject gamemanager = GameObject.FindWithTag("GameManager");
        if (player > gamemanager.GetComponent<GameManagerScript>().playerCount)
        {
            gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
