using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuActions : MonoBehaviour
{
    public void ChangeScene(int sceneid)
    {
        SceneManager.LoadScene(sceneid, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

