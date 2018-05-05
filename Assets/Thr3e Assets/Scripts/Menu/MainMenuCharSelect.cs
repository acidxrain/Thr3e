using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuCharSelect : MonoBehaviour {

    public GameMenuActions gameMenuActions;

    public void ChangeLevel(int sceneid)
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        StartCoroutine(gameMenuActions.SetPauseInactive());
    }

}
