using UnityEngine;
using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Sensor;

public class ImageSubscriber : MonoBehaviour
{
    public string topicName;
    public Renderer targetRenderer;
    private ROSConnection ros;
    private Texture2D tex;
    private bool isMessageReceived = false;
    
    void Start()
    {
        ros = ROSConnection.instance;
        ros.Subscribe<ImageMsg>(topicName, ReceiveMsg);

        tex = new Texture2D(640, 480, TextureFormat.RGB24, false);
    }

    void ReceiveMsg(ImageMsg compressedImage)
    {
        if (!isMessageReceived) {
            Debug.Log("Received");
            byte[] imageData = compressedImage.data;
            ProcessMessage(imageData);
        }
    }

    private void ProcessMessage(byte[] data)
    {        
        tex.LoadRawTextureData(data);
        targetRenderer.material.mainTexture = tex;
        tex.Apply();
    }

}
