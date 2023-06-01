using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSostoianie2 : MonoBehaviour
{
    public GameObject OblakoParticle;
    public GameObject OblakoZeliaParticle;
    public Transform Bird;
    int Oblako = 0;
    float Timer;
    public float Oblakotime = 10f;

    public GameObject VodopadParticle;
    public GameObject VodopadZeliaParticle;
    int Vodopad = 0;
    float TimerVodopad;
    public float Vodopadtime = 10f;

    int Mech = 0;
    float TimerMech;
    public float Mechtime = 5f;
    public GameObject MechZeliaParticle;

    int Topor = 0;
    float TimerTopor;
    public float Toportime = 5f;
    public GameObject ToporZeliaParticle;

    public int intTopor = 0, intMech = 0, intOblako = 0, intVodopad = 0;
    // Start is called before the first frame update

    void Start()
    {
        Zelia_Off();
    }

    public void Zelia_Off()
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

    // Update is called once per frame
    void Update()
    {
        Control_Zelia();

        if (Oblako == 1) Timer += Time.deltaTime;

        if (Timer > Oblakotime)
        {
            Oblako_Off();
        }

        if (Vodopad == 1) TimerVodopad += Time.deltaTime;

        if (TimerVodopad > Vodopadtime)
        {
            Vodopad_Off();
        }

        if (Mech == 1) TimerMech += Time.deltaTime;

        if (TimerMech > Mechtime)
        {
            Mech_Off();
        }

        if (Topor == 1) TimerTopor += Time.deltaTime;

        if (TimerTopor > Toportime)
        {
            Topor_Off();
        }
    }

    public void Control_Zelia()
    {
        if (Input.GetKey(KeyCode.Q)) OblakoClick();
        if (Input.GetKey(KeyCode.W)) VodopadClick();
        if (Input.GetKey(KeyCode.E)) MechClick();
        if (Input.GetKey(KeyCode.R)) ToporClick();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
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
            if(other.gameObject.tag == "Tkan")
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

    //Выключения действий зелей

    public void Oblako_Off()
    {
        Timer = 0;
        Oblako = 0;
        PlayerPrefs.SetInt("SaveOblako", Oblako);
        PlayerPrefs.Save();
        OblakoZeliaParticle.SetActive(false);
    }

    public void Vodopad_Off()
    {
        TimerVodopad = 0;
        Vodopad = 0;
        PlayerPrefs.SetInt("SaveVodopad", Vodopad);
        PlayerPrefs.Save();
        VodopadZeliaParticle.SetActive(false);
    }

    public void Mech_Off()
    {
        TimerMech = 0;
        Mech = 0;
        PlayerPrefs.SetInt("SaveMech", Mech);
        PlayerPrefs.Save();
        MechZeliaParticle.SetActive(false);
    }

    public void Topor_Off()
    {
        TimerTopor = 0;
        Topor = 0;
        PlayerPrefs.SetInt("SaveTopor", Topor);
        PlayerPrefs.Save();
        ToporZeliaParticle.SetActive(false);
    }

    //Кнопки

    public void OblakoClick()
    {
        OblakoZeliaParticle.SetActive (true);
        Oblako = 1;
        PlayerPrefs.SetInt("SaveOblako", Oblako);
        PlayerPrefs.Save();
    }

    public void VodopadClick()
    {
        VodopadZeliaParticle.SetActive(true);
        Vodopad = 1;
        PlayerPrefs.SetInt("SaveVodopad", Vodopad);
        PlayerPrefs.Save();
    }

    public void MechClick()
    {
        MechZeliaParticle.SetActive(true);
        Mech = 1;
        PlayerPrefs.SetInt("SaveMech", Mech);
        PlayerPrefs.Save();
    }

    public void ToporClick()
    {
        ToporZeliaParticle.SetActive(true);
        Topor = 1;
        PlayerPrefs.SetInt("SaveTopor", Topor);
        PlayerPrefs.Save();
    }
}
