using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public GameMenuActions gameMenuActions;

    public void Exit()
    {
        StartCoroutine(gameMenuActions.ExitGame());
    }
}
