using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Add this script to the player game object
/// </summary>
public class FadeObstructingObjects : MonoBehaviour
{
    /// <summary>
    /// Internal class to keep track of the fading object
    /// </summary>
    private class FadeObject
    {
        public GameObject GameObject { get; set; }
        public FadeObjectOptions Options { get; set; }
        public float TransparencyLevel { get; set; }
        public List<Shader> OrigionalShaders = new List<Shader>();
    }

    private class NotifyFadeSystem : MonoBehaviour
    {
        void OnDestroy()
        {
            FadeObstructingObjects.RemoveFadingObject(this.gameObject);
        }
    }

    // Shader to use for fading
    public Shader FadeShader = null;

    // Camera viewing the object this script is on
    public Camera Camera;

    // Seconds it takes to fade
    public float Seconds = 1f;
    
    // A ray is cast from the camera to the object this script is on
    public float RayRadius = 0.25f;
    
    // The final alpha value of the objects being faded
    public float FinalAlpha = 0.1f;
    
    // Objects on layers to fade
    public LayerMask LayerMask = ~0;

    static List<FadeObject> HiddenObjects = new List<FadeObject>();

    // Check to see if a game object is faded
    public static bool IsHidden(GameObject go)
    {
        return HiddenObjects.FirstOrDefault(x => x.GameObject == go) != null;
    }

    void Update()
    {
        HideWallsRayCast();
    }

    private void HideWallsRayCast()
    {

        Vector3 diffVector = gameObject.transform.position - Camera.transform.position;

        Ray ray = new Ray(Camera.main.transform.position, Vector3.Normalize(diffVector));
        RaycastHit[] hits = Physics.SphereCastAll(ray, RayRadius, diffVector.magnitude, LayerMask.value);
        
        foreach (RaycastHit hit in hits)
        {
            // Get the collider
            Collider c = hit.collider;

            // Dont consider the object this script is placed on
            if (c.gameObject == gameObject || c.gameObject.GetComponent<Renderer>() == null)
                continue;

            // If the object is already hidden
            FadeObject hiddenObject = HiddenObjects.FirstOrDefault(x => x.GameObject == c.gameObject);
            if (hiddenObject == null)
            {
                // Get the object fade options
                FadeObjectOptions fadeObjectOptions = c.gameObject.GetComponent<FadeObjectOptions>();
                
                // If the maximum fade is set to 1 then this object won't be hidden, so skip it
                if (fadeObjectOptions != null && fadeObjectOptions.FinalAlpha == 1)
                    continue;

                hiddenObject = new FadeObject { GameObject = c.gameObject, TransparencyLevel = 1.0f };
                
                // Store the origional shader
                foreach (Material m in c.gameObject.GetComponent<Renderer>().materials)
                {
                    hiddenObject.OrigionalShaders.Add(m.shader);
                    if (fadeObjectOptions != null && fadeObjectOptions.FadeShader != null)
                        m.shader = fadeObjectOptions.FadeShader;
                    else
                    {
                        m.shader = FadeShader;
                    }
                }

                //
                hiddenObject.Options = fadeObjectOptions;

                // Add to hidden objects
                HiddenObjects.Add(hiddenObject);
                c.gameObject.AddComponent<NotifyFadeSystem>();
            }
        }

        // Unhide the objects that are not hidden anymore
        HiddenObjects.RemoveAll(x =>
        {
            float fadeSeconds = x.Options != null && x.Options.Seconds != -1 ? x.Options.Seconds : Seconds;
            
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.gameObject == x.GameObject)
                {
                    // Change the transparency of already hidden items
                    float maximumFade = x.Options != null && x.Options.FinalAlpha != -1 ? x.Options.FinalAlpha : FinalAlpha;
                    if (x.TransparencyLevel > maximumFade)
                    {
                        x.TransparencyLevel -= Time.deltaTime * (1.0f / fadeSeconds);

                        if (x.TransparencyLevel <= maximumFade)
                            x.TransparencyLevel = maximumFade;

                        foreach (Material m in x.GameObject.GetComponent<Renderer>().materials)
                            m.color = new Color(m.color.r, m.color.g, m.color.b, x.TransparencyLevel);

                        // Reached the intended level of fade, disable the renderer if the alpha is 0
                        if (x.TransparencyLevel == maximumFade && x.TransparencyLevel == 0)
                            x.GameObject.GetComponent<Renderer>().enabled = false;
                    }

                    return false;
                }
            }

            // Bring the object up to full transparency before removing it from the fade list 
            if (x.TransparencyLevel < 1.0f)
            {
                // Renable the renderer if the transparency level was 0
                if (x.TransparencyLevel == 0)
                    x.GameObject.GetComponent<Renderer>().enabled = true;

                x.TransparencyLevel += Time.deltaTime * (1.0f / fadeSeconds);
                if (x.TransparencyLevel > 1)
                    x.TransparencyLevel = 1;

                foreach (Material m in x.GameObject.GetComponent<Renderer>().materials)
                {
                    m.color = new Color(m.color.r, m.color.g, m.color.b, x.TransparencyLevel);
                }

                return false;
            }

            // Swap to the origional shaders
            for (int i = 0; i < x.GameObject.GetComponent<Renderer>().materials.Length; i++)
            {
                x.GameObject.GetComponent<Renderer>().materials[i].shader = x.OrigionalShaders[i];
            }

            // Remove the FadedObject monobehaviour
            Destroy(x.GameObject.GetComponent<NotifyFadeSystem>());

            return true;
        });


    }

    /// <summary>
    /// Remove an object from the fading sytem, called on destroy by 
    /// FadedObject which is added when the object enters the fade system
    /// </summary>
    /// <param name="gameObject"></param>
    internal static void RemoveFadingObject(GameObject gameObject)
    {
        HiddenObjects.RemoveAll(x => x.GameObject == gameObject);
    }
}