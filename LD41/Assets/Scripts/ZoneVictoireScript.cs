using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneVictoireScript : MonoBehaviour {

    GameObject[] joueursDansLaZone = new GameObject[4];
    GameManagerScript gameManagerScript;
    int players;
    public int numberOfPlayersAround;

	// Use this for initialization
	void Start () {
        gameManagerScript = GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>();
        players = gameManagerScript.playerCount;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        numberOfPlayersAround = HowManyElementsAreInMyArray(joueursDansLaZone);
		if (numberOfPlayersAround == players)
        {
            gameManagerScript.LoadNextLevel();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int numeroPlayerColliding = collision.gameObject.GetComponent<Car2DController>().player;
            numeroPlayerColliding += -1;
            joueursDansLaZone[numeroPlayerColliding] = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            int numeroPlayerColliding = collision.gameObject.GetComponent<Car2DController>().player;
            numeroPlayerColliding += -1;
            joueursDansLaZone[numeroPlayerColliding] = null;
        }
    }

    int HowManyElementsAreInMyArray(GameObject[] a)
    {
        int ohyeahbaby = 0;
        for(int i = 0; i < 4; i++)
        {   
            if(a[i] != null) ohyeahbaby++;
        }
        return ohyeahbaby;
    }

}
