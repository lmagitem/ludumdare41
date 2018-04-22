using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSpawnScript : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        GameObject prefab = Resources.Load("Prefabs/CarPlayer") as GameObject;
        GameObject gamemanager = GameObject.FindWithTag("GameManager");
        for(int i = 0; i < gamemanager.GetComponent<GameManagerScript>().playerCount; i++)
        {
            Vector3 tempTransform = gameObject.transform.position; 
            GameObject temp = Instantiate(prefab, new Vector3(transform.position.x + (-0.6f + (i * 0.4f)), transform.position.y, -1.5f), transform.localRotation);
            temp.GetComponent<Car2DController>().player = i + 1;
            temp.name = "Player" + temp.GetComponent<Car2DController>().player.ToString();
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
