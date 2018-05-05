using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour {

    public void SaveAndExit()
    {
        //This needs to be changed later to save the actual game data!
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        //This needs to be changed later to save the actual game data!
        Application.Quit();
    }
}
