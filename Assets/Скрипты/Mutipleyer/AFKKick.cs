using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class AFKKick : MonoBehaviourPunCallbacks//, IPunObservable
{

    float TimerAfkOnePlayer = 0, TimerAfkSG_En;
    public Text Text;// textTimer1, textTimer2;
    public StartGame SG;
    public LeaveRoom LR;
    public AFKKick AFK;
    public Cameracontrol CC;

    void Start()
    {
        PlayerPrefs.SetInt("SaveAfk", 0);
    }

    void Update()
    {
        if (PhotonNetwork.PlayerList.Length == 1) TimerAfkOnePlayer += Time.deltaTime;
        else TimerAfkOnePlayer = 0;
        if (SG.enabled == true) TimerAfkSG_En += Time.deltaTime;
        else TimerAfkSG_En = 0;

        //textTimer1.text = "Из за одного игрока " + TimerAfkOnePlayer;
        //textTimer2.text = "Из за Включеного SG " + TimerAfkSG_En;

        if(TimerAfkOnePlayer > 150 || TimerAfkSG_En > 30)
        {
            if(TimerAfkOnePlayer - 150 > TimerAfkSG_En)
            {
                float a = 180 - TimerAfkOnePlayer;
                Text.text = "Вы будете изключены, если продолжите играть один, через: " + a.ToString("0.00"); ;
            }
            else
            {
                float a = 60 - TimerAfkSG_En;
                Text.text = "Вы будете изключены за бездействие через: " + a.ToString("0.00");
            }
        }
        else
        {
            Text.text = " ";
        }
        if (TimerAfkOnePlayer > 180)
        {
            PlayerPrefs.SetInt("SaveAfk", 1);
            LR.Leave();
            CC.enabled = false;
            AFK.enabled = false;
        }

        if (TimerAfkSG_En > 60 )
        {
            PlayerPrefs.SetInt("SaveAfk", 1);
            LR.Leave();
            CC.enabled = false;
            AFK.enabled = false;
        }
    }
}