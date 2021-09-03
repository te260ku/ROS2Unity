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
        // start the ROS connection
        ros = ROSConnection.instance;

        //Publish
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
            //Send untiy_odom to turtlebot_control
            PosRot cubePos = new PosRot(
                cube.transform.position.x,
                cube.transform.position.y,
                cube.transform.position.z,
                cube.transform.rotation.x,
                cube.transform.rotation.y,
                cube.transform.rotation.z,
                cube.transform.rotation.w
                );

            // Finally send the message to server_endpoint.py running in ROS
            ros.Send("unity_odom", cubePos);

            //Manual Emergency Stop
            if (Input.GetKey(KeyCode.DownArrow))
            {
                status = false;
            }
        }
    }
}