using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    public int playerCount = 1;
    public int currentLevel = 0;
	private static bool created = false;

	// Use this for initialization
	void Awake () {
		if (!created)
		{
			DontDestroyOnLoad (gameObject);
			created = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UnJoueur()
    {
        playerCount = 1;
        LoadNextLevel();
    }
    public void DeuxJoueurs()
    {
        playerCount = 2;
        LoadNextLevel();
    }
    public void TroisJoueurs()
    {
        playerCount = 3;
        LoadNextLevel();
    }
    public void QuatreJoueurs()
    {
        playerCount = 4;
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        currentLevel += 1;
        Application.LoadLevel("Level" + currentLevel);
    }
}
