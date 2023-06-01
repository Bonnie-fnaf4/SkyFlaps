using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlanMultiplayer : MonoBehaviourPunCallbacks
{
    float Timer = 0;
    void Update()
    {
        //if (!photonView.IsMine) return;
        //Timer += Time.deltaTime;
        //if(Timer >= 0.5)
        //{
        //    if(PlayerPrefs.GetInt("SaveHostBug") == 1) PhotonNetwork.Destroy(gameObject);
        //}
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        //if(photonView.IsMine) 
            PhotonNetwork.Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        PhotonNetwork.Destroy(gameObject);
    }
}
