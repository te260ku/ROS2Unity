using UnityEngine;
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
        ros.Subscribe<CompressedImageMsg>(topicName, ReceiveMsg);

        tex = new Texture2D(1, 1);
    }

    void ReceiveMsg(CompressedImageMsg compressedImage)
    {
        Debug.Log("Received Image");
        byte[] imageData = compressedImage.data;
        
        RenderTexture(imageData);
    }

    private void RenderTexture(byte[] data)
    {        
        tex.LoadImage(data);
        targetRenderer.material.mainTexture = tex;
        tex.Apply();
    }

}
