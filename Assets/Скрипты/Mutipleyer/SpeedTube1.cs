using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpeedTube1 : MonoBehaviourPunCallbacks
{
    int a = 1;
    //SpeedTube speed;
    SpeedTube1 speed1;
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        //speed = GetComponent<SpeedTube>();

        speed1 = GetComponent<SpeedTube1>();
        transform.Translate(direction * Time.deltaTime);
        a = PlayerPrefs.GetInt("SpeedTubeDelete");
        if (a == 0 && (!photonView.IsMine))
        {
            a = 1;
            PlayerPrefs.SetInt("SpeedTubeDelete", a);
            //speed.enabled = false;
            speed1.enabled = false;
        }
    }
    void Update()
    {
        //if(PlayerPrefs.GetInt("SaveSG") == 1) speed1.enabled = false;
        speed1 = GetComponent<SpeedTube1>();
        transform.Translate(direction * Time.deltaTime);

    }
}
