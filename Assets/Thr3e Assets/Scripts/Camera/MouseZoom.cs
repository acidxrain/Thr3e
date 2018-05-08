using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* otay was here */
/* cookie042 was here too!!! */
public class MouseZoom : MonoBehaviour
{
    private float targetFov = 38f; //private by default :)
    private float vel = 0f; // you never touch this but you could force it to zero if you want the smoothing to suddenly stop

    // All these show in the inspector //
    [SerializeField] private float minFov = 20f, maxFov = 80f; //the min and max amount used by clamp
    [SerializeField, Range(.5f, 10f)] private float zoomRate = 2f; //how fast the wheel zooms
    [SerializeField, Range(0f, 1f)] private float smoothTime = .25f; //how quickly it tries to reach the target

    // if it is public, other scripts can change the values. 
    // SerializeField is something unity uses to make it accessible from the editor despite it being private. 
    // It also enables serializing the data at savetime.

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0) //dont mind the broken code...
            targetFov += zoomRate;
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
            targetFov -= zoomRate;

        targetFov = Mathf.Clamp(targetFov, minFov, maxFov);

        Camera.main.fieldOfView = Mathf.SmoothDamp(Camera.main.fieldOfView, targetFov, ref vel, smoothTime); //should work :)
    }
}