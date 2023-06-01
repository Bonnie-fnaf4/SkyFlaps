using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PovorotTextPriCI : MonoBehaviour
{
    public Transform Text;
    public SpeedTube ST;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("SaveCameraInversia") == 1)
        {
            Text = GetComponent<Transform>();
            ST = GetComponent<SpeedTube>();
            ST.direction.x = ST.direction.x * -1;
            Text.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
}
