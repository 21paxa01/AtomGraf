using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraAspect : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float screenRatio;
    
    private void Start()
    {
        _camera.orthographicSize = screenRatio * ( (float)Screen.height/ Screen.width );
    }
    private void OnValidate()
    {
        if (Application.isPlaying)
            return;
        if(!_camera)
        {
            _camera = GetComponent<Camera>();
        }
       // screenRatio = _camera.orthographicSize / (1280  / 720f);
    }
}
