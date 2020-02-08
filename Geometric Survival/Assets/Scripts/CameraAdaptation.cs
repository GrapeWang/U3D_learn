using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdaptation : MonoBehaviour
{
 //   private float devHeight = 10.8f;
    private float devWidth = 19.2f;
    // Start is called before the first frame update
    void Start()
    {
        float orthSize = GetComponent<Camera>().orthographicSize;
        float aspectRatio = Screen.width * 1.0f / Screen.height;
  //      float cameraWidth = orthSize * 2 * aspectRatio;
        this.GetComponent<Camera>().orthographicSize = devWidth / (aspectRatio * 2);
    }

}
