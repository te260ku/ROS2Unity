using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Geometry;

public class TwistPublisher : MonoBehaviour
{
    public string topicName;
    public float publishMessageFrequency = 0.5f;
    private ROSConnection ros;
    private float timeElapsed;
    [SerializeField]
    private JoyStickHandler joyStickHandler;
    private float linearSpeed = 0.05f;
    private float angularSpeed = 0.2f;
    public enum MANIPULATION_MODE {
        STICK, 
        KEY
    }
    public MANIPULATION_MODE manipulationMode;

    void Start()
    {
        ros = ROSConnection.instance;
        ros.RegisterPublisher<TwistMsg>(topicName);
        

        
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > publishMessageFrequency)
        {

            float linear_x = 0f;
            float angular_z = 0f;

            if (manipulationMode == MANIPULATION_MODE.STICK) {
                JoyStickHandler.JOY_STICK_INPUT joyStickInput = joyStickHandler.GetJoyStickInput();
                switch (joyStickInput)
                {
                    case JoyStickHandler.JOY_STICK_INPUT.NONE:
                        break;
                    case JoyStickHandler.JOY_STICK_INPUT.UP:
                        linear_x = linearSpeed;
                        break;
                    case JoyStickHandler.JOY_STICK_INPUT.DOWN:
                        linear_x = -linearSpeed;
                        break;
                    case JoyStickHandler.JOY_STICK_INPUT.LEFT:
                        angular_z = angularSpeed;
                        break;
                    case JoyStickHandler.JOY_STICK_INPUT.RIGHT:
                        angular_z = -angularSpeed;
                        break;
                    default:
                        break;
                }
            } else if (manipulationMode == MANIPULATION_MODE.KEY) {

                if (Input.GetKey(KeyCode.UpArrow)) {
                    linear_x = 0.5f;
                }
                if (Input.GetKey(KeyCode.DownArrow)) {
                    linear_x = -0.5f;
                }
                if (Input.GetKey(KeyCode.LeftArrow)) {
                    angular_z = -0.5f;
                }
                if (Input.GetKey(KeyCode.RightArrow)) {
                    linear_x = 0.5f;
                }
                
            }
            
            
            Vector3Msg linear = new Vector3Msg(linear_x, 0f, 0f);
            Vector3Msg angular = new Vector3Msg(0f, 0f, angular_z);
            TwistMsg twist = new TwistMsg(linear, angular);
            SendTwistMsg(twist);
            
            timeElapsed = 0;
        }
    }

    private void SendTwistMsg(TwistMsg msg)
    {
        ros.Send(topicName, msg);
    }
}
