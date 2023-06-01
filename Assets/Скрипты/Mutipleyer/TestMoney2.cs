using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class TestMoney2 : MonoBehaviour, IPunObservable
{
    private PhotonView photonView;
    public int money, m2;

    //
    public GameObject OblakoParticle;
    public GameObject OblakoZeliaParticle;
    public Transform Bird;
    public int Oblako = 0;
    float Timer;
    public float Oblakotime = 10f;

    public GameObject VodopadParticle;
    public GameObject VodopadZeliaParticle;
    public int Vodopad = 0;
    float TimerVodopad;
    public float Vodopadtime = 10f;

    public int Mech = 0;
    float TimerMech;
    public float Mechtime = 5f;
    public GameObject MechZeliaParticle;

    public int Topor = 0;
    float TimerTopor;
    public float Toportime = 5f;
    public GameObject ToporZeliaParticle;

    public int intTopor = 0, intMech = 0, intOblako = 0, intVodopad = 0;
    //

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
            Oblako = 0;
            PlayerPrefs.SetFloat("SaveOblakotime", Oblakotime);
            PlayerPrefs.SetInt("SaveOblako", Oblako);
            Vodopad = 0;
            PlayerPrefs.SetFloat("SaveVodopadtime", Vodopadtime);
            PlayerPrefs.SetInt("SaveVodopad", Vodopad);
            Mech = 0;
            PlayerPrefs.SetFloat("SaveMechtime", Mechtime);
            PlayerPrefs.SetInt("SaveMech", Mech);
            Topor = 0;
            PlayerPrefs.SetFloat("SaveToportime", Toportime);
            PlayerPrefs.SetInt("SaveTopor", Topor);
            PlayerPrefs.Save();

        intTopor = PlayerPrefs.GetInt("SaveMechBuy");
        intMech = PlayerPrefs.GetInt("SaveMechBuy");
            intOblako = PlayerPrefs.GetInt("SaveOblakoBuy");
            intVodopad = PlayerPrefs.GetInt("SaveVodopadBuy");
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
        }
        else
        {
            Oblako = (int)stream.ReceiveNext();
            Vodopad = (int)stream.ReceiveNext();
            Mech = (int)stream.ReceiveNext();
            Topor = (int)stream.ReceiveNext();
            if (Oblako == 1)OblakoZeliaParticle.SetActive(true);
            else OblakoZeliaParticle.SetActive(false);
            if (Vodopad == 1) VodopadZeliaParticle.SetActive(true);
            else VodopadZeliaParticle.SetActive(false);
            if (Mech == 1) MechZeliaParticle.SetActive(true);
            else MechZeliaParticle.SetActive(false);
            if (Topor == 1) ToporZeliaParticle.SetActive(true);
            else ToporZeliaParticle.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!(photonView.IsMine)) 
        {
            return; 
        }
        if (Input.GetKey(KeyCode.Q)) OblakoClick();
        if (Input.GetKey(KeyCode.W)) VodopadClick();
        if (Input.GetKey(KeyCode.E)) MechClick();
        if (Input.GetKey(KeyCode.R)) ToporClick();

        if (Oblako == 1) Timer += Time.deltaTime;
        if (Timer > Oblakotime)
        {
            Timer = 0;
            Oblako = 0;
            PlayerPrefs.SetInt("SaveOblako", Oblako);
            PlayerPrefs.Save();
            OblakoZeliaParticle.SetActive(false);
        }

        if (Vodopad == 1) TimerVodopad += Time.deltaTime;
        if (TimerVodopad > Vodopadtime)
        {
            TimerVodopad = 0;
            Vodopad = 0;
            PlayerPrefs.SetInt("SaveVodopad", Vodopad);
            PlayerPrefs.Save();
            VodopadZeliaParticle.SetActive(false);
        }

        if (Mech == 1) TimerMech += Time.deltaTime;
        if (TimerMech > Mechtime)
        {
            TimerMech = 0;
            Mech = 0;
            PlayerPrefs.SetInt("SaveMech", Mech);
            PlayerPrefs.Save();
            MechZeliaParticle.SetActive(false);
        }

        if (Topor == 1) TimerTopor += Time.deltaTime;
        if (TimerTopor > Toportime)
        {
            TimerTopor = 0;
            Topor = 0;
            PlayerPrefs.SetInt("SaveTopor", Topor);
            PlayerPrefs.Save();
            ToporZeliaParticle.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!photonView.IsMine) return;
        if (other.gameObject.tag == "Oblako")
        {
            if (intOblako == 1)
            {
                OblakoZeliaParticle.SetActive(true);
                Oblako = 1;
                PlayerPrefs.SetInt("SaveOblako", Oblako);
                PlayerPrefs.Save();
            }
            else
            {
                GameObject g = Instantiate(OblakoParticle, Bird.position, Quaternion.identity);
                Destroy(g, 2);
            }
        }

        if (other.gameObject.tag == "Vodopad")
        {
            if (intVodopad == 1)
            {
                VodopadZeliaParticle.SetActive(true);
                Vodopad = 1;
                PlayerPrefs.SetInt("SaveVodopad", Vodopad);
                PlayerPrefs.Save();
            }
            else
            {
                GameObject g = Instantiate(VodopadParticle, Bird.position, Quaternion.identity);
                Destroy(g, 2);
            }
        }
        if (!(intMech == 1) && other.gameObject.tag == "Tkan")
        {
            PlayerPrefs.SetInt("SaveintBlue", 1);
            PlayerPrefs.Save();
        }
        else
        {
            if (other.gameObject.tag == "Tkan")
            {
                MechClick();
            }
        }


        if (!(intTopor == 1) && other.gameObject.tag == "Brevno")
        {
            PlayerPrefs.SetInt("SaveintBlue", 1);
            PlayerPrefs.Save();
        }
        else
        {
            if (other.gameObject.tag == "Brevno")
            {
                ToporClick();
            }
        }
    }
    public void OblakoClick()
    {
        if (!photonView.IsMine) return;
        OblakoZeliaParticle.SetActive(true);
        Oblako = 1;
        PlayerPrefs.SetInt("SaveOblako", Oblako);
        PlayerPrefs.Save();
    }

    public void VodopadClick()
    {
        if (!photonView.IsMine) return;
        VodopadZeliaParticle.SetActive(true);
        Vodopad = 1;
        PlayerPrefs.SetInt("SaveVodopad", Vodopad);
        PlayerPrefs.Save();
    }

    public void MechClick()
    {
        if (!photonView.IsMine) return;
        MechZeliaParticle.SetActive(true);
        Mech = 1;
        PlayerPrefs.SetInt("SaveMech", Mech);
        PlayerPrefs.Save();
    }

    public void ToporClick()
    {
        if (!photonView.IsMine) return;
        ToporZeliaParticle.SetActive(true);
        Topor = 1;
        PlayerPrefs.SetInt("SaveTopor", Topor);
        PlayerPrefs.Save();
    }
}
