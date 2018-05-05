using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuActions : MonoBehaviour {

    public GameObject pauseMenu;
    public bool Paused = false;
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
            StartCoroutine (SetPauseActive());
        }

        // Disable pause menu
        else if (Input.GetKeyDown(KeyCode.Escape) && Paused)
        {
            StartCoroutine(SetPauseInactive());
        }
    }

    public IEnumerator SetPauseActive()
    {
        pauseMenu.SetActive(true);
        Paused = true;
        Time.timeScale = 0f;
        yield return null;
    }

    public IEnumerator SetPauseInactive()
    {
        pauseMenu.SetActive(false);
        Paused = false;
        Time.timeScale = 1f;
        yield return null;
    }

    public IEnumerator ResumeGame()
    {
        StartCoroutine (SetPauseInactive());
        yield return null;
    }

    public IEnumerator ChangeScene(int sceneid)
    {
        SceneManager.LoadScene(sceneid, LoadSceneMode.Single);
        yield return null;
    }

    public IEnumerator ExitGame()
    {
        //Set this up later to save the player data.
        Application.Quit();
        yield return null;
    }
}
