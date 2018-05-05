using UnityEngine;
using System.Reflection;


/// <summary>
/// Automatically provides a version number to a project and displays
/// it for 20 seconds at the start of the game.
/// </summary>
/// <remarks>
/// Change the first two number to update the major and minor version number.
/// The following number are the build number (which is increased automatically
///  once a day, and the revision number which is increased every second). 
/// </remarks>
[assembly: AssemblyVersion("0.0.*")]
public class VersionNumber : MonoBehaviour
{
    /// <summary>
    /// Can be set to true, in that case the version number will be shown in bottom right of the screen
    /// </summary>
    public bool ShowVersionInformation = true;
    /// <summary>
    /// Show the version during the first 20 seconds.
    /// </summary>
    public bool ShowVersionDuringTheFirst20Seconds = false;
    string version;
    public Rect position = new Rect(1800, 1035, 200, 200);

    /// <summary>
    /// Gets the version.
    /// </summary>
    /// <value>The version.</value>
    public string Version
    {
        get
        {
            if (version == null)
            {
                version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
            return version;
        }
    }


    /// Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this);

        // Log current version in log file
        Debug.Log(string.Format("Currently running version is {0}", Version));

        if (ShowVersionDuringTheFirst20Seconds)
        {
            ShowVersionInformation = true;
            Destroy(this, 20f);
        }

        position.x = 1800f;
        position.y = 1035f;

    }


    void OnGUI()
    {
        if (!ShowVersionInformation)
        {
            return;
        }

        GUI.contentColor = Color.red;
        GUI.Label(position, string.Format("v{0}", Version));
        GUI.skin.label.fontSize = 15;
    }
}