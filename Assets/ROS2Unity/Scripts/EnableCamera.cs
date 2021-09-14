using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class EnableCamera : MonoBehaviour
{
    void Start()
    {
        GetComponent<Camera>().enabled = false;
        GetComponent<Camera>().enabled = true;
    }

    void Update()
    {
        
    }
}
