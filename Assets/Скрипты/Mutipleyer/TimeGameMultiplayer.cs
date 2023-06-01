using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class TimeGameMultiplayer : MonoBehaviourPunCallbacks, IPunObservable
{
    private PhotonView photonView;
    public float a = 0, b = 1, j = 0;
    public bool d = false, g = true, f = true, h = true;
    public int SettingTime;
    public Text c;
    //TimeGame TimeGameScript;
    TestMoney TM;
    public bool StartGameI = false, HostP = false, IfHost;
    //
    public bool end = false;
    public float timer = 20, endTimer;
    public Text TextTimer;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine) return;
        timer = 20;
        TM = GetComponent<TestMoney>();
        PlayerPrefs.SetFloat("SaveB", b);
       // PlayerPrefs.SetFloat("SaveTimeB", 0);
       // TimeGameScript = GetComponent<TimeGame>();
        Time.timeScale = 1;
        PlayerPrefs.SetInt("SaveSG", 0);
        SettingTime = PlayerPrefs.GetInt("SaveSetting1.5x");
        if (b < 1.4f)
        {
            if (SettingTime == 1)
            {
                b = 1.5f;
                PlayerPrefs.SetFloat("SaveTimeB", b);
                Time.timeScale = b;
                //PlayerPrefs.SetFloat("SaveB", 1.3f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine) return;
        IfHost = TM.NameHostBool2;
        if (!StartGameI)
        {
            if (IfHost) HostP = true;
            StartGameI = true;
        }
        if (!HostP)
        {
            b = PlayerPrefs.GetFloat("SaveB");
            PlayerPrefs.SetFloat("SaveTimeB", b);
            SettingTime = PlayerPrefs.GetInt("SaveSettingTime");
            Time.timeScale = b;
            c.text = "b = " + b + " a = " + a + " HostP = " + HostP;
            timer = PlayerPrefs.GetFloat("SaveTimerTimeGame");
            if (timer < 0)
            {
                end = true;
                //timer = 20;
                //PlayerPrefs.SetFloat("SaveTimerTimeGame", timer);
            }
            if (end) endTimer += Time.deltaTime;
            if (endTimer > 1)
            {
                end = false;
                endTimer = 0;
                timer = 20;
                PlayerPrefs.SetFloat("SaveTimerTimeGame", timer);
            }
            TextTimer.text = "" + timer.ToString("0.00");

        }
        else
        {
            if (d == false) { if (PlayerPrefs.GetInt("SaveSG") == 1) d = true; }
            else
            {
                //
                if (!end) timer -= Time.deltaTime;
                if (timer < 0)
                {
                    end = true;
                    //timer = 20;
                }
                if (end) endTimer += Time.deltaTime;
                if (endTimer > 1)
                {
                    end = false;
                    endTimer = 0;
                    timer = 20;
                }
                TextTimer.text = "" + timer.ToString("0.00");
                //
                if (g && !(Time.timeScale == 0)) a += Time.deltaTime;
                if (a >= 30 && !(Time.timeScale == 0) && b <= 1.5)
                {
                    g = false;
                    b += Time.deltaTime / 120;
                    Time.timeScale = b;
                    PlayerPrefs.SetFloat("SaveTimeB", b);
                    if (b <= 1.3) PlayerPrefs.SetFloat("SaveB", b);
                }
                if (a >= 90 && !(Time.timeScale == 0) && b >= 1.5)
                {
                    g = false;
                    b += Time.deltaTime / 240;
                    Time.timeScale = b;
                    PlayerPrefs.SetFloat("SaveTimeB", b);
                    if (b <= 1.3) PlayerPrefs.SetFloat("SaveB", b);
                }
                c.text = "b = " + b + " a = " + a + " d = " + d + " g = " + g + " f = " + f + " h = " + h;
                if (b > 1.5 && f)
                {
                    PlayerPrefs.SetFloat("SaveTimeB", b);
                    f = false;
                    a = 0;
                    if(!(SettingTime == 2)) g = true;
                }
                if (b >= 2 && !f)
                {
                    h = false;
                    b = 2;
                    Time.timeScale = b;
                    PlayerPrefs.SetFloat("SaveTimeB", b);
                }
            }
        }
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(b);
            stream.SendNext(SettingTime);
            stream.SendNext(timer);
        }
        else
        {
            b = (float)stream.ReceiveNext();
            SettingTime = (int)stream.ReceiveNext();
            timer = (float)stream.ReceiveNext();
            PlayerPrefs.SetFloat("SaveTimerTimeGame", timer);
            if (!IfHost && b > 1)
            {
                PlayerPrefs.SetFloat("SaveB", b);
                PlayerPrefs.SetInt("SaveSettingTime", SettingTime);
            }
        }
    }
    public override void OnPlayerLeftRoom(Player otherPlayer) //Если игрок покинул комнату то обнулить Старт игры на всякий случаи и проверить игрока на хоста
    {
        StartGameI = false;
    }
}
