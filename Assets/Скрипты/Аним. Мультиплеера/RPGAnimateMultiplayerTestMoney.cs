using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class RPGAnimateMultiplayerTestMoney : MonoBehaviour, IPunObservable
{
    private PhotonView photonView;
    public string parametrs;
    int Oblako = 0;
    int Vodopad = 0;
    int Mech = 0;
    int Topor = 0;

    int Blue;
    public GameObject BlueParticleSystem;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        anim = GetComponent<Animator>();
        if (!(photonView.IsMine))
        {
            return;
        }
        else
        {

        }
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(Oblako);
            stream.SendNext(Vodopad);
            stream.SendNext(Mech);
            stream.SendNext(Topor);
            stream.SendNext(Blue);
        }
        else
        {
            Oblako = (int)stream.ReceiveNext();
            Vodopad = (int)stream.ReceiveNext();
            Mech = (int)stream.ReceiveNext();
            Topor = (int)stream.ReceiveNext();
            Blue = (int)stream.ReceiveNext();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!(photonView.IsMine))
        {

        }
        else
        {
            Oblako = PlayerPrefs.GetInt("SaveOblako");
            Vodopad = PlayerPrefs.GetInt("SaveVodopad");
            Mech = PlayerPrefs.GetInt("SaveMech");
            Topor = PlayerPrefs.GetInt("SaveTopor");
            Blue = PlayerPrefs.GetInt("SaveintBlue");
        }
        if (parametrs == "Oblako")
        {
            if (Oblako == 1) anim.SetBool("Oblako", true);
            if (Oblako == 0) anim.SetBool("Oblako", false);
        }
        if (parametrs == "Vodopad")
        {
            if (Vodopad == 1) anim.SetBool("Vodopad", true);
            if (Vodopad == 0) anim.SetBool("Vodopad", false);
        }
        if (parametrs == "Mech")
        {
            if (Mech == 1) anim.SetBool("Mech", true);
            if (Mech == 0) anim.SetBool("Mech", false);
        }
        if (parametrs == "Topor")
        {
            if (Topor == 1) anim.SetBool("Topor", true);
            if (Topor == 0) anim.SetBool("Topor", false);
        }
        if (Blue == 1) BlueParticleSystem.SetActive(true);
        if (Blue == 0) BlueParticleSystem.SetActive(false);
    }
}
