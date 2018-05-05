using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Place this script on an object that needs to override the fade options
/// Override the fade objects per object
/// </summary>
public class FadeObjectOptions : MonoBehaviour
{
    public float Seconds = -1;
    public float FinalAlpha = -1;
    public Shader FadeShader = null;
}