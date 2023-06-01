using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class BlueParticleMultiplayer : MonoBehaviour
{
    private PhotonView photonView;
    int Blue;
    public GameObject BlueParticleSystem;
    // Update is called once per frame
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }
    void Update()
    {
        if (photonView.IsMine)
        {
            Blue = PlayerPrefs.GetInt("SaveintBlue");
        }
        if (Blue == 1) BlueParticleSystem.SetActive(true);
        if (Blue == 0) BlueParticleSystem.SetActive(false);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(Blue);
        }
        else
        {
            Blue = (int)stream.ReceiveNext();
        }
    }
}
