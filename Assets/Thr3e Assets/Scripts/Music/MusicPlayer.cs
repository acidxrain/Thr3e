using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;

    void Awake()
    {
        // If the music player doesn't exist in our scene, place it.
        if (!instance)
            instance = this;
        // Otherwise, destroy this game object.
        else
            Destroy(this.gameObject);
    }
}
