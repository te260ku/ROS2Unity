using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Turtlesim : MonoBehaviour
{
    [HideInInspector]
    public Vector3 linearSpeed { get; set; }
    [HideInInspector]
    public Vector3 angularSpeed { get; set; }
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        Move(this.linearSpeed, this.angularSpeed); 
    }

    private void Move(Vector3 linear, Vector3 angular)
    {
        rb.velocity = transform.forward * (float)linear.x;
        rb.angularVelocity = new Vector3(0, -(float)angular.z, 0);
    }

    public void SetSpeed(Vector3 linear, Vector3 angular) {
        this.linearSpeed = linear;
        this.angularSpeed = angular;
    }

        

}