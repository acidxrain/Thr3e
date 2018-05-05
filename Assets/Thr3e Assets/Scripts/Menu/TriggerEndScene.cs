using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TriggerEndScene : MonoBehaviour
{
    void OnTriggerEnter(Collider box)
    {
        //End the pre-alpha. Show player end game scene.
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
}
