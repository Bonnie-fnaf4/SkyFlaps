using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInversia : MonoBehaviour
{
    public Transform Camera;
    public bool On = false;
    public bool Check = true;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GetComponent<Transform>();
        //PlayerPrefs.SetInt("SaveCameraInversia", 1);
        //Camera.rotation = Quaternion.Euler(0, 0, 180);
        //On = true;
        //Check = true;
    }
    void Update()
    {
        if(On && !Check)
        {
            PlayerPrefs.SetInt("SaveCameraInversia", 1);
            Camera.rotation = Quaternion.Euler(0, 0, 180);
            Check = false;
        }
        if (!On && !Check)
        {
            PlayerPrefs.SetInt("SaveCameraInversia", 0);
            Camera.rotation = Quaternion.Euler(0, 0, 0);
            Check = false;
        }
    }
}
