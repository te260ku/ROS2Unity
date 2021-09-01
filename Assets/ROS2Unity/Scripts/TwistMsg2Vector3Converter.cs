using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosMessageTypes.Geometry;

public static class TwistMsg2Vector3Converter
{
    public static Vector3Speed TwistMsg2Vector3(TwistMsg msg) {
        Vector3 linear = new Vector3((float)msg.linear.x, (float)msg.linear.y, (float)msg.linear.z);
        Vector3 angular = new Vector3((float)msg.angular.x, (float)msg.angular.y, (float)msg.angular.z);
        Vector3Speed speed = new Vector3Speed(linear, angular);
        return speed;
    }
}

public class Vector3Speed
{
    public Vector3 linear;
    public Vector3 angular;
    public Vector3Speed(Vector3 linear, Vector3 angular) {
        this.linear = linear;
        this.angular = angular;
    }
}
