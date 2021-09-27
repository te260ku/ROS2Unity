using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watermelon : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        GameObject target = other.gameObject;
        if (target.tag == "Stick") {
            DestroySelf();
        }
    }

    private void DestroySelf() {
        Destroy(this.gameObject);
    }
}
