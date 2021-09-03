using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using PosRot = RosMessageTypes.UnityRoboticsDemo.PosRotMsg;

public class OdomPublisher : MonoBehaviour
{
    ROSConnection ros;
    public GameObject cube;    
    float unity_odom = 0.0f;
    bool status = false;

    void Start()
    {
        ros = ROSConnection.instance;
        ros.RegisterPublisher<PosRot>("unity_odom");
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            status = true;
        }

        if (status == true)
        {
            cube.transform.position += transform.forward * 0.05f * Time.deltaTime;

            PosRot cubePos = new PosRot(
                cube.transform.position.x,
                cube.transform.position.y,
                cube.transform.position.z,
                cube.transform.rotation.x,
                cube.transform.rotation.y,
                cube.transform.rotation.z,
                cube.transform.rotation.w
                );

            ros.Send("unity_odom", cubePos);

            if (Input.GetKey(KeyCode.DownArrow))
            {
                status = false;
            }
        }
    }
}