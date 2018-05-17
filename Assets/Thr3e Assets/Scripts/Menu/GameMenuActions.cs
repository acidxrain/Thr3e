using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuActions : MonoBehaviour
{

    public GameObject pauseText;
    public GameObject deadText;
    public bool Paused;
    private bool pause;
    public bool IsAlive;
    public PlayerInterface playerInterface;

    public void Start()
    {
        pause = GetComponent<Canvas>();
        pauseText.SetActive(false);
        deadText.SetActive(false);
    }

    void Update()
    {
        IsAlive = playerInterface.isAlive;

        // Enable pause menu
        if (Input.GetKeyDown(KeyCode.Escape) && !Paused && IsAlive)
        {
            //We need to disable the player input to navmesh here.
            pauseText.SetActive(true);
            Paused = true;
            pause.Equals(true);
            Time.timeScale = 0f;
        }

        // Disable pause menu
        else if (Input.GetKeyDown(KeyCode.Escape) && Paused && IsAlive)
        {
            // Re-enable player input to navmesh here.
            pauseText.SetActive(false);
            Paused = false;
            pause.Equals(false);
            Time.timeScale = 1f;
        }

        else if (!IsAlive)
        {
            deadText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                playerInterface.Respawn();
            }
        }
    }

    // Execute when player presses "Escape" while dead to turn off the death menu text.
    public void DisableDeadText()
    {
        deadText.SetActive(false);
    }

    // Execute when player presses "Resume" from options menu
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseText.SetActive(false);
        Paused = false;
    }

    public void Options()
    {
        // Keep commented until options scene is finished.
        // SceneManager.LoadScene(4, LoadSceneMode.Additive);
    }

    public void SaveAndExit()
    {
        // This needs to be changed later to save the actual game data!
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        Time.timeScale = 1f;
    }
}
