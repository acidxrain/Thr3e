using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuActions : MonoBehaviour
{
    public OptionsMenu optionsMenu;

    public void ChangeScene(int sceneid)
    {
        SceneManager.LoadScene(sceneid, LoadSceneMode.Single);
    }

    public void Options()
    {
        if (optionsMenu.ShowOptions == false)
        {
            optionsMenu.ShowOptionsMenu();
        }
        else
        {
            return;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

