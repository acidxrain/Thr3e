using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResumeGame : MonoBehaviour
{
    public GameMenuActions gameMenuActions;

    public void Resume()
    {
        StartCoroutine(gameMenuActions.ResumeGame());
    }
}

