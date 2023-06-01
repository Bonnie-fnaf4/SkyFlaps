using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class ListItem : MonoBehaviour
{
    public int CL, SL = 0, Number = 1;
    [SerializeField] Text textName;
    [SerializeField] Text textPlayerCount;

    public void SetInfo(RoomInfo info)
    {
        textName.text = info.Name;
        textPlayerCount.text = info.PlayerCount + "/" + info.MaxPlayers;
    }
    void Start()
    {
        Number = PlayerPrefs.GetInt("Number");
        PlayerPrefs.SetInt("Number", Number + 1);
    }
    void Update()
    {
        CL = PlayerPrefs.GetInt("SaveCL");
        if (CL == 1)
        {
            if(PlayerPrefs.GetInt("Number") == (Number + 1))
            {
                CL = 0;
                PlayerPrefs.SetInt("SaveCL", CL);
                PlayerPrefs.SetInt("Number", 0);
            }
            Destroy(gameObject);
        }
    }
    public void JoinRoom()
    {
        PlayerPrefs.SetInt("SaveintSloshnost", SL);
        PhotonNetwork.JoinRoom(textName.text);
    }
}
