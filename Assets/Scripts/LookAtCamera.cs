using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Camera _cam;

    private void Start()
    {
        _cam = Camera.main;
    }

   private void Update()
    {
        Quaternion rotation = _cam.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.back);
    }
}
