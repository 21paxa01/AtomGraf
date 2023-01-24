using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BWMode : MonoBehaviour
{
    public static float test;
    public static bool mod;
    public PostProcessVolume script;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        script.weight = test;
    }
}
