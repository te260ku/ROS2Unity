using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Geometry;

public class TurtlesimController : MonoBehaviour
{
    [SerializeField]
    private Turtlesim turtlesim;
    ROSConnection ros;
    
    void Start()
    {
        ros = ROSConnection.instance;
        ros.Subscribe<TwistMsg>("cmd_vel", ReceiveTwistMsg);
    }

    void ReceiveTwistMsg(TwistMsg msg)
    {
        Vector3Speed speed = TwistMsg2Vector3Converter.TwistMsg2Vector3(msg);
        turtlesim.SetSpeed(speed.linear, speed.angular);
    }
}
