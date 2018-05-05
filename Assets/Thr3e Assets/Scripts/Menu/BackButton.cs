using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{

    public void PreviousScene()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
