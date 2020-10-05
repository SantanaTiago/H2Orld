using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
		
	}


    public void LoadMainGame()
    {
        SceneManager.LoadScene("MainGame");
        Debug.Log("Loading MainGame...");
    }

    public void LoadPuzzleGame()
    {
        SceneManager.LoadScene("SlidingTilePuzzle");
        Debug.Log("Loading PuzzleGame...");
    }

    public void LoadWaterState()
    {
        SceneManager.LoadScene("WaterStates");
        Debug.Log("Loading WaterStates...");
    }

    public void QuitGame()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}
