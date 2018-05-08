using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuActions : MonoBehaviour {

    public GameObject pauseMenu;
    public bool Paused;
    public bool pause;

    public void Start()
    {
        pause = GetComponent<Canvas>();
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        // Enable pause menu
        if (Input.GetKeyDown(KeyCode.Escape) && !Paused)
        {
            //We need to disable the player input to navmesh here.
            pauseMenu.SetActive(true);
            Paused = true;
            pause.Equals(true);
            Time.timeScale = 0f;
        }

        // Disable pause menu
        else if (Input.GetKeyDown(KeyCode.Escape) && Paused)
        {
            //Re-enable player input to navmesh here.
            pauseMenu.SetActive(false);
            Paused = false;
            pause.Equals(false);
            Time.timeScale = 1f;
        }
    }

    //Execute when player presses "Resume" from options menu
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Paused = false;
    }
    
    public void Options()
    {
        //Keep commented until options scene is finished.
        //SceneManager.LoadScene(4, LoadSceneMode.Additive);
    }
    
    public void SaveAndExit()
    {
        //This needs to be changed later to save the actual game data!
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
