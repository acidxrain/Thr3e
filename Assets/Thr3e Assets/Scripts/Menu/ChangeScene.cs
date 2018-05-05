using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public GameMenuActions gameMenuActions;

    public void ChangeLevel(int sceneid)
    {
        StartCoroutine(gameMenuActions.ChangeScene(0));
    }
}
