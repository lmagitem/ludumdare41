﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSpawnScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject prefab = Resources.Load("CarPlayer") as GameObject;
        GameObject gamemanager = GameObject.FindWithTag("GameManager");
        for(int i = 0; i < gamemanager.GetComponent<GameManagerScript>().playerCount; i++)
        {
            Vector3 tempTransform = gameObject.transform.position; 
           // GameObject temp = Instantiate(prefab, new Vector3(, gameObject.transform.localRotation, null);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
