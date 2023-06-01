using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] ListItem itemPrefab;
    [SerializeField] Transform content;
    public Text LogText, NickNameText;
    public int CL = 0;

    public Text NameRoom, CountPlayer;
    byte CountPlayerInt = 10;
    public GameObject NameRoomPlaceholder;
    public string NameRoomString;

    public GameObject Loading;
    //
    public int Number;
       float timer = 0;
    // Start is called before the first frame update
    private void Start()
    {
        NickNameText.text = PlayerPrefs.GetString("SaveNick");
        if (NickNameText.text == "")
        {
            PhotonNetwork.NickName = "Player" + Random.Range(1000, 9999);
        }
        else
        {
            PhotonNetwork.NickName = NickNameText.text;
            PlayerPrefs.SetString("SaveNick", NickNameText.text);
        }
        Log("Вашь ник был задан как - " + PhotonNetwork.NickName);

        //
        PlayerPrefs.SetInt("SaveTubeColor", 0);
        PlayerPrefs.SetInt("SaveCI", 0);
        PlayerPrefs.SetInt("SaveBI", 0);
        PlayerPrefs.SetInt("SaveCameraInversia", 0);
        //
        PlayerPrefs.SetFloat("SaveMMA", 0);
        PlayerPrefs.SetFloat("SaveMMF", 0);
        PlayerPrefs.SetInt("SaveMMB", 0);
        PlayerPrefs.SetInt("SaveMMN1", 0);
        PlayerPrefs.SetInt("SaveMMN2", 0);
        PlayerPrefs.SetInt("SaveMMN3", 0);
        //
        PlayerPrefs.SetInt("SavePVPBreak2", 0);
        PlayerPrefs.SetInt("SavePVPBreak", 0);
        PlayerPrefs.SetInt("SaveWaitPlayer", 0);
        PlayerPrefs.SetInt("SaveintBlue", 0);
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
        PlayerPrefs.SetInt("SaveLeave", 0);
        PlayerPrefs.SetString("SaveId", "");
        PlayerPrefs.SetInt("SpeedTubeDelete", 0);
        PlayerPrefs.SetInt("SaveBestRecords", 0);
        PlayerPrefs.SetInt("Number", 1);
        PlayerPrefs.SetInt("HostNameInt", 0);
        PlayerPrefs.SetString("SaveHostName", "");
        PlayerPrefs.SetInt("SaveUpHost", 0);
        PlayerPrefs.SetInt("SaveSG", 0);
        PlayerPrefs.SetFloat("SaveTimeB", 1);
        PlayerPrefs.SetInt("SaveMMX", 1);
        PlayerPrefs.SetInt("SaveSettingTime", 0);

        PlayerPrefs.SetInt("SaveintYellow", 0);

        PlayerPrefs.SetInt("SaveJoinInGame", 0);
        for (int i = 2; i <= 10; i++)
        {
            PlayerPrefs.SetInt("SaveM" + i, 0);
            PlayerPrefs.SetInt("SaveRecords2" + i, 0);
            PlayerPrefs.SetInt("SavePVPBreak2" + i, 0);
            PlayerPrefs.SetString("SaveNick2" + i, "" + i);
        }
        Time.timeScale = 1;
    }

    public override void OnConnectedToMaster()
    {
        Log("Вы подключились к серверу с регионом - " + PhotonNetwork.CloudRegion);
        PhotonNetwork.JoinLobby();
        if(!((PhotonNetwork.CloudRegion == "ru") || (PhotonNetwork.CloudRegion == "ru/*")))
        {
            PhotonNetwork.Disconnect();
            PhotonNetwork.ConnectToRegion("ru");
        }
    }
    public void JoinRoom()
    {
        Log("Хуй");
        PhotonNetwork.JoinRandomRoom();
        PlayerPrefs.SetInt("SaveintSloshnost", 0);
        PlayerPrefs.SetInt("SaveMutatorInt", 0);
    }

    public void CreateRoom()
    {
        if (PhotonNetwork.CloudRegion == null)
        {
            Loading.SetActive(false);
            Log("Не удалось создать к комнату");
        }
        else
        {
            if (PlayerPrefs.GetInt("SaveintSloshnost") == 0 || PlayerPrefs.GetInt("SaveintSloshnost") == 4) PlayerPrefs.SetInt("SaveintSloshnost", Random.Range(1, 3));
            NameRoomString = NameRoom.text;
            if (NameRoom.text == "") NameRoomString = PhotonNetwork.NickName;
            ConvertInt();
            PlayerPrefs.SetInt("HostNameInt", 1);
            PhotonNetwork.CreateRoom(NameRoomString, new Photon.Realtime.RoomOptions { MaxPlayers = CountPlayerInt});
            PlayerPrefs.SetInt("SaveJoinInGame", 1);
            Loading.SetActive(true);
        }
    }

    public void ConvertInt()
    {
        if(CountPlayer.text == "1")
        {
            CountPlayerInt = 10;
        }
        else
        {
            if (CountPlayer.text == "2")
            {
                CountPlayerInt = 2;
            }
            else
            {
                if (CountPlayer.text == "3")
                {
                    CountPlayerInt = 3;
                }
                else
                {
                    if (CountPlayer.text == "4")
                    {
                        CountPlayerInt = 4;
                    }
                    else
                    {
                        if (CountPlayer.text == "5")
                        {
                            CountPlayerInt = 5;
                        }
                        else
                        {
                            if (CountPlayer.text == "6")
                            {
                                CountPlayerInt = 6;
                            }
                            else
                            {
                                if (CountPlayer.text == "7")
                                {
                                    CountPlayerInt = 7;
                                }
                                else
                                {
                                    if (CountPlayer.text == "8")
                                    {
                                        CountPlayerInt = 8;
                                    }
                                    else
                                    {
                                        if (CountPlayer.text == "9")
                                        {
                                            CountPlayerInt = 9;
                                        }
                                        else
                                        {
                                            if (CountPlayer.text == "10")
                                            {
                                                CountPlayerInt = 10;
                                            }
                                            else
                                            {
                                                CountPlayerInt = 10;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public override void OnJoinedRoom()
    {
        Log("Вы входите в комнату");
        Loading.SetActive(true);
        PhotonNetwork.LoadLevel("Gemplay");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Loading.SetActive(false);
        Log("Не удалось создать к комнату");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Loading.SetActive(false);
        Log("Не удалось подключится к комнате");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Loading.SetActive(false);
        Log("Не удалось подключится к комнате");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
            {
            ListItem listItem;
            listItem = Instantiate(itemPrefab, content);
            listItem.SetInfo(info);
        }
    }
    public void UpdateListLM()
    {
        PhotonNetwork.LeaveLobby();
        CL = 0;
        PlayerPrefs.SetInt("SaveCL", CL);
        PhotonNetwork.JoinLobby();
    }
    public void CleanListLM()
    {
        CL = 1;
        timer = 0;
        PlayerPrefs.SetInt("SaveCL", CL);
    }
    void Update()
    {
        timer += Time.deltaTime;
        Number = PlayerPrefs.GetInt("Number");
        if (PlayerPrefs.GetInt("Number") == 0)
        {
            PlayerPrefs.SetInt("Number", 1);
            UpdateListLM();
        }
        if(timer >= 3)
        {
            CleanListLM();
        }
    }

    public void SetNick()
    {
        PhotonNetwork.NickName = NickNameText.text;
        PlayerPrefs.SetString("SaveNick", NickNameText.text);
        Log("Вашь ник был задан как - " + PhotonNetwork.NickName);
    }
    public void CleanNick()
    {
        NickNameText.text = "";
        PlayerPrefs.SetString("SaveNick", NickNameText.text);
        PhotonNetwork.NickName = "Player" + Random.Range(1000, 9999);
        Log("Вашь ник был задан как - " + PhotonNetwork.NickName);
    }
    private void Log(string message)
    {
        Debug.Log(message);
        LogText.text += "\n";
        LogText.text += message;
    }
    public void CloseLoading()
    {
        Loading.SetActive(false);
    }
}
