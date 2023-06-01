using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class PVP : MonoBehaviour, IPunObservable
{
    private PhotonView photonView;
    public int PVPBreak, PVPBreak2 = 0, a = 0, b = 0; // а и б помоему не работают...
    public float Afk = 10; //Время допустимого бездействия
    public string id = "0";
    public GameObject Lose, Win, Wait, Wait2, AfkPanel; // Список панелек. Воит 2 помоему уже не работает...
    public Text aa,bb, dd, ee, AfkText;
    public Text[] cc = new Text[9];
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (!(photonView.IsMine))
        {
            return;
        }
        else
        {
            PVPBreak = PlayerPrefs.GetInt("SavePVPBreak"); // Для чего то это точно нужно. Хотя потом вроде в Упдайти это всё равно проверяется
        }
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(PVPBreak);
        }
        else
        {
            PVPBreak = (int)stream.ReceiveNext();
            if(!(id == "0") && (PVPBreak == 1))PlayerPrefs.SetInt("SavePVPBreak2" + id, PVPBreak);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine) return;
        if (id == "0") id = PlayerPrefs.GetString("SaveId");
        PVPBreak = PlayerPrefs.GetInt("SavePVPBreak");
        if (PlayerPrefs.GetInt("SaveLeave") == 1) 
        {
            for (int i = 2; i <= 10; i++)
            {
                PlayerPrefs.SetInt("SavePVPBreak2" + i, 0);
            }
        }
        if ((PlayerPrefs.GetInt("SaveLeave") == 1) && (PhotonNetwork.PlayerList.Length == 1) && (Lose.activeSelf == false)) Win.SetActive(true);


        if (PhotonNetwork.PlayerList.Length == 2)
        {
            for (int i = 2; i <= PhotonNetwork.PlayerList.Length; i++)
            {
                if (1 == PlayerPrefs.GetInt("SavePVPBreak2" + i))
                {
                    b += 1;
                }
                if (b + 1 == PhotonNetwork.PlayerList.Length) PVPBreak2 = 1;
            }
        }
        ee.text = "b == " + b;
        b = 0;

        AfkText.text = "Вы вернётесь в деревню через - " + Afk;

        dd.text = "PvpBreak2 == " + PVPBreak2;

        if ((PVPBreak == 1) && (PlayerPrefs.GetInt("SaveRecords") < PlayerPrefs.GetInt("SaveBestRecords"))) 
        {
            Lose.SetActive(true);
            Wait.SetActive(false);
        }

        if ((PVPBreak2 == 1) && (PlayerPrefs.GetInt("SaveRecords") >= PlayerPrefs.GetInt("SaveBestRecords")))
            Win.SetActive(true);

        if ((PVPBreak == 1) && (a == 0) && (PlayerPrefs.GetInt("SaveRecords") >= PlayerPrefs.GetInt("SaveBestRecords")))
            Wait.SetActive(true);


        if ((PVPBreak2 == 1) && (PlayerPrefs.GetInt("SaveRecords") < PlayerPrefs.GetInt("SaveBestRecords"))) 
            Wait2.SetActive(true);
        aa.text = "SaveBestRecords == " + PlayerPrefs.GetInt("SaveBestRecords");
        bb.text = "SaveRecords == " + PlayerPrefs.GetInt("SaveRecords");

        if ((Lose.activeSelf == true) || (Win.activeSelf == true))
        {
            Afk -= Time.deltaTime;
            AfkPanel.SetActive(true);
        }
        if (Afk <= 0) PhotonNetwork.LeaveRoom();
    }
    public void WaitPlayer()
    {
        a = 1;
        PlayerPrefs.SetInt("SaveWaitPlayer", a);
        Wait.SetActive(false);
    }
}
