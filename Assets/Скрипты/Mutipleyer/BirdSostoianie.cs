using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class BirdSostoianie : MonoBehaviour
{
    //public GameObject OblakoParticle;
    public GameObject OblakoZeliaParticle;
    public Transform Bird;
    public int Oblako = 0;
    float Timer;
    public float Oblakotime = 10f;

    //public GameObject VodopadParticle;
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
    private PhotonView photonView;

    public int a = 1;
    // Start is called before the first frame update
    void Start()
    {
        a = 1;
        photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine) return;
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
    }
    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine) return;
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

    ///                      !!! ЭТА ЧАСТЬ КОДА НАХОДИТСЯ В TESTMONEY2 !!! ТАМ ВКЛЮЧЕНА СИНХРОНИЗАЦИЯ СЕТЕВАЯ

    // void OnTriggerEnter2D(Collider2D other)
    //{
    //  if (other.gameObject.tag == "Oblako")
    //  {
    //if (Oblako == 1)
    //{
    //     OblakoZeliaParticle.SetActive(true);
    //     Oblako = 1;
    //     PlayerPrefs.SetInt("SaveOblako", Oblako);
    //     PlayerPrefs.Save();
    //}
    //else
    //{
    //   GameObject g = Instantiate(OblakoParticle, Bird.position, Quaternion.identity);
    //   Destroy(g, 2);
    //}
    // }
    ///                      !!! ЭТА ЧАСТЬ КОДА НАХОДИТСЯ В TESTMONEY2 !!! ТАМ ВКЛЮЧЕНА СИНХРОНИЗАЦИЯ СЕТЕВАЯ
    //if (other.gameObject.tag == "Vodopad")
    // {
    //if (Vodopad == 1)
    //{
    //      VodopadZeliaParticle.SetActive(true);
    //     Vodopad = 1;
    //      PlayerPrefs.SetInt("SaveVodopad", Vodopad);
    //     PlayerPrefs.Save();
    //}
    //else
    //{
    //    GameObject g = Instantiate(VodopadParticle, Bird.position, Quaternion.identity);
    //    Destroy(g, 2);
    //}
    // }
    //}
    public void OblakoClick()
    {
        if (!photonView.IsMine) return;
        OblakoZeliaParticle.SetActive (true);
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
