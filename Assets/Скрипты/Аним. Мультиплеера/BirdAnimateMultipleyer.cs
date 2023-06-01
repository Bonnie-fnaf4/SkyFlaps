using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BirdAnimateMultipleyer : MonoBehaviour
{
    private PhotonView photonView;
    Animator anim;
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (!(photonView.IsMine))
        {
            return;
        }
        anim = GetComponent < Animator >();
    }

    void Update()
    {
        if (!(photonView.IsMine))
        {
            return;
        }
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Fly");
        }
    }
}
