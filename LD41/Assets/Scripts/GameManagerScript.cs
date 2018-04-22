using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    public int playerCount = 1;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UnJoueur()
    {
        playerCount = 1;
    }
    public void DeuxJoueurs()
    {
        playerCount = 2;
    }
    public void TroisJoueurs()
    {
        playerCount = 3;
    }
    public void QuatreJoueurs()
    {
        playerCount = 4;
    }
}
