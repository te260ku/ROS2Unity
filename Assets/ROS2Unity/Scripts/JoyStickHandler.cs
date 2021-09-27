using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickHandler : MonoBehaviour
{
    public enum JOY_STICK_INPUT {
        NONE, 
        UP, 
        DOWN, 
        LEFT, 
        RIGHT, 
    }
    private JOY_STICK_INPUT joyStickInput;

    void Start()
    {
        
    }

    void Update()
    {
        joyStickInput = JOY_STICK_INPUT.NONE;
        if (OVRInput.Get(OVRInput.RawButton.LThumbstickUp))
        {
            Debug.Log("<<上>>");
            joyStickInput = JOY_STICK_INPUT.UP;
        }
        if (OVRInput.Get(OVRInput.RawButton.LThumbstickDown))
        {
            Debug.Log("<<下>>");
            joyStickInput = JOY_STICK_INPUT.DOWN;
        }
        if (OVRInput.Get(OVRInput.RawButton.LThumbstickLeft))
        {
            Debug.Log("<<左>>");
            joyStickInput = JOY_STICK_INPUT.LEFT;
        }
        if (OVRInput.Get(OVRInput.RawButton.LThumbstickRight))
        {
            Debug.Log("<<右>>");
            joyStickInput = JOY_STICK_INPUT.RIGHT;
        }
    }

    public JOY_STICK_INPUT GetJoyStickInput() {
        return this.joyStickInput;
    }
}
