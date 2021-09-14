using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Sensor;
using OpenCvSharp.Demo;
using OpenCvSharp;
using OpenCvSharp.Aruco;

public class ImageSubscriber : MonoBehaviour
{
    public string topicName;
    public Renderer targetRenderer;
    private ROSConnection ros;
    private Texture2D tex;
    private bool isMessageReceived = false;
    public enum IMAGE_MODE {
        NORMAL, 
        BINARY, 
    }
    public IMAGE_MODE imageMode;
    
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
        
        switch (imageMode)
        {
            case IMAGE_MODE.NORMAL:
                targetRenderer.material.mainTexture = tex;
                break;
            case IMAGE_MODE.BINARY:
                targetRenderer.material.mainTexture = GetBinaryTexture(tex);
                break;
            default:
                break;
        }
        
        tex.Apply();
    }

    private Texture2D GetBinaryTexture(Texture2D tex) {
        Mat mat = OpenCvSharp.Unity.TextureToMat(tex);

        // グレースケール
        Mat gray = new Mat();
        Cv2.CvtColor(mat, gray, ColorConversionCodes.BGR2GRAY);

        // 二値化
        Mat bin = new Mat();
        Cv2.Threshold(gray, bin, 127, 255, ThresholdTypes.Binary);

        Texture2D outTexture = new Texture2D(mat.Width, mat.Height, TextureFormat.ARGB32, false);
        OpenCvSharp.Unity.MatToTexture(bin, outTexture);

        return outTexture;
    }

}
