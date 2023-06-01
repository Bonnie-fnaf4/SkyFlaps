using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNotInversia : MonoBehaviour
{
    public Transform Camera;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GetComponent<Transform>();
        PlayerPrefs.SetInt("SaveCameraInversia", 0);
        Camera.rotation = Quaternion.Euler(0, 0, 0);
    }
}
