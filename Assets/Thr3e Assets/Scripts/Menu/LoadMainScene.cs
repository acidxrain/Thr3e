using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMainScene : MonoBehaviour {

    public void BeginGame()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
