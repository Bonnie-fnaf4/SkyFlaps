using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class MytantManagerMultiplayer : MonoBehaviour, IPunObservable
{
    private PhotonView photonView;
    
    public GameObject Number1, Number2, Number3;
    public GameObject TextCI, TextBI, TextTN;
    public GameObject Sld;
    public Slider Slider;
    public CameraInversia CI;
    public BirdInversionMultiplayer BI;
    public BirdControl BL2;
    public GameObject Bird;
    public Transform BirdTransform;
    public float a = 0, f = 0;
    public int b = 0, bb = 0;
    public int checkMMX = 1;
    public bool c0 = true, c1 = true, c2 = true, c3 = true;
    public bool n1 = false, n2 = false, n3 = false;

    public bool n32 = false, n22 = false;

    public bool act = true, start = true;

    public bool StartGameI = false, HostP = false;
    public TimeGameMultiplayer TGM;
    public Text c;
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
            TGM = GetComponent<TimeGameMultiplayer>();

            BI = GetComponent<BirdInversionMultiplayer>();
            BL2 = GetComponent<BirdControl>();

            bb = 3;
            f = 90;
            a = 40;
        }
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(a);
            stream.SendNext(f);

            stream.SendNext(b);
            stream.SendNext(bb);

            stream.SendNext(n1);
            stream.SendNext(n2);
            stream.SendNext(n3);

            stream.SendNext(n22);
            stream.SendNext(n32);

            stream.SendNext(HostP);
        }
        else
        {
            a = (float)stream.ReceiveNext();
            f = (float)stream.ReceiveNext();

            b = (int)stream.ReceiveNext();
            bb = (int)stream.ReceiveNext();

            n1 = (bool)stream.ReceiveNext();
            n2 = (bool)stream.ReceiveNext();
            n3 = (bool)stream.ReceiveNext();

            n22 = (bool)stream.ReceiveNext();
            n32 = (bool)stream.ReceiveNext();

            HostP = (bool)stream.ReceiveNext();
            PlayerPrefs.SetFloat("SaveMMA", a);
            PlayerPrefs.SetFloat("SaveMMF", f);
            PlayerPrefs.SetInt("SaveMMB", b);
            PlayerPrefs.SetInt("SaveMMBB", bb);
            if (n1) PlayerPrefs.SetInt("SaveMMN1", 1);
            if (n2) PlayerPrefs.SetInt("SaveMMN2", 1);
            if (n3) PlayerPrefs.SetInt("SaveMMN3", 1);

            if (n22) PlayerPrefs.SetInt("SaveMMN22", 1);
            else PlayerPrefs.SetInt("SaveMMN22", 0);
            if (n32) PlayerPrefs.SetInt("SaveMMN32", 1);
            else PlayerPrefs.SetInt("SaveMMN32", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!(photonView.IsMine)) 
        {
            return; 
        }
        c.text = "f = " + f + " a = " + a + " b = " + b + " bb = " + bb + " n1 = " + n1 + " n2 = " + n2 + " n3 = " + n3 + " n22 = " + n22 + " n32 = " + n32;
        if (!act) return;
        HostP = TGM.HostP; //Проверка на Хоста
        if (!HostP)
        {
            a = PlayerPrefs.GetFloat("SaveMMA");
            f = PlayerPrefs.GetFloat("SaveMMF");
            b = PlayerPrefs.GetInt("SaveMMB"); // b если ты не Хост

            if (PlayerPrefs.GetInt("SaveMMN1") == 1)
            {
                PlayerPrefs.SetInt("SaveTubeColor", 1);
                n1 = true;
                PlayerPrefs.SetInt("SaveMMX", PlayerPrefs.GetInt("SaveMMX") + 2);
                
            }
            if (PlayerPrefs.GetInt("SaveMMN2") == 1)
            {
                BI.enabled = true;
                BL2.Inver2 = true;
                n2 = true; ;
                
                PlayerPrefs.SetInt("SaveMMX", PlayerPrefs.GetInt("SaveMMX") + 2);
            }
            if (PlayerPrefs.GetInt("SaveMMN3") == 1)
            {
                CI.enabled = true;
                BL2.Inver = true;
                n3 = true;
                
                PlayerPrefs.SetInt("SaveMMX", PlayerPrefs.GetInt("SaveMMX") + 2);
            }


            if (PlayerPrefs.GetInt("SaveMMN32") == 0)
            {
                CameraInvers_Off();
                

            }
            if (PlayerPrefs.GetInt("SaveMMN22") == 0)
            {
                BirdInvers_Off();

            }


            if (PlayerPrefs.GetInt("SaveMMN32") == 1)
            {
                CameraInvers_On();
               

            }
            if (PlayerPrefs.GetInt("SaveMMN22") == 1)
            {
                BirdInvers_On();
                

            }


            if (n1 && n2 && n3)
            {
                PlayerPrefs.SetInt("SaveMMX", 6);
                act = false;
            }

            //


            if (a >= 44 && c3) // Ифы для отображение цифр отсчёта
            {
                GameObject g = Instantiate(Number1, BirdTransform.position, Quaternion.identity);
                Destroy(g, 3);
                c3 = false;
            }
            else
            {
                if (a >= 43 && c2)
                {
                    GameObject g = Instantiate(Number2, BirdTransform.position, Quaternion.identity);
                    Destroy(g, 3);
                    c2 = false;
                }
                else
                {
                    if (a >= 42 && c1)
                    {
                        GameObject g = Instantiate(Number3, BirdTransform.position, Quaternion.identity);
                        Destroy(g, 3);
                        c1 = false;
                    }
                    if (a >= 40 && c0)
                    {
                        Sld.SetActive(true);
                        b = PlayerPrefs.GetInt("SaveMMB");

                        //while ((n3 && b == 1) || (n2 && b == 2) || (n1 && b == 3)) b = Random.Range(0, 3);

                       bb = PlayerPrefs.GetInt("SaveMMBB");

                        if (b == 2 && bb == 3)
                        {
                            GameObject h = Instantiate(TextTN, BirdTransform.position, Quaternion.identity);
                            Destroy(h, 5);
                        }
                        if (b == 1 && bb == 3)
                        {
                            GameObject h = Instantiate(TextBI, BirdTransform.position, Quaternion.identity);
                            Destroy(h, 5);
                        }
                        if (b == 0 && bb == 3)
                        {
                            GameObject h = Instantiate(TextCI, BirdTransform.position, Quaternion.identity);
                            Destroy(h, 5);
                        }
                        if (b == 1 && bb == 2)
                        {
                            GameObject h = Instantiate(TextBI, BirdTransform.position, Quaternion.identity);
                            Destroy(h, 5);
                        }
                        if (b == 0 && bb == 2)
                        {
                            GameObject h = Instantiate(TextCI, BirdTransform.position, Quaternion.identity);
                            Destroy(h, 5);
                        }
                        c0 = false;
                    }
                }
            }


            if (a >= 40) Slider.value = a;



            if (a >= 44)
            {
                Sld.SetActive(false);
            }
        }
        else // Начало скрипта для Хоста
        {
            if (start) f += Time.deltaTime;
            if (f >= 90)
            {
                start = false;
                a += Time.deltaTime;
                if (a >= 44 && c3)
                {
                    GameObject g = Instantiate(Number1, BirdTransform.position, Quaternion.identity);
                    Destroy(g, 3);
                    c3 = false;
                }
                else
                {
                    if (a >= 43 && c2)
                    {
                        GameObject g = Instantiate(Number2, BirdTransform.position, Quaternion.identity);
                        Destroy(g, 3);
                        c2 = false;
                    }
                    else
                    {
                        if (a >= 42 && c1)
                        {
                            GameObject g = Instantiate(Number3, BirdTransform.position, Quaternion.identity);
                            Destroy(g, 3);
                            c1 = false;
                        }
                        if (a >= 40 && c0)
                        {
                            Sld.SetActive(true);
                            b = Random.Range(0, 3);
                            if (!(n3 && n2 && n1))
                                while ((n3 && b == 0) || (n2 && b == 1) || (n1 && b == 2) || (bb == 2)) b = Random.Range(0, bb);

                            if (bb == 2) b = Random.Range(0, bb);

                            if (b == 2 && bb == 3)
                            {
                                GameObject h = Instantiate(TextTN, BirdTransform.position, Quaternion.identity);
                                Destroy(h, 5);
                            }
                            if (b == 1 && bb == 3)
                            {
                                GameObject h = Instantiate(TextBI, BirdTransform.position, Quaternion.identity);
                                Destroy(h, 5);
                            }
                            if (b == 0 && bb == 3)
                            {
                                GameObject h = Instantiate(TextCI, BirdTransform.position, Quaternion.identity);
                                Destroy(h, 5);
                            }
                            if (b == 1 && bb == 2)
                            {
                                GameObject h = Instantiate(TextBI, BirdTransform.position, Quaternion.identity);
                                Destroy(h, 5);
                            }
                            if (b == 0 && bb == 2)
                            {
                                GameObject h = Instantiate(TextCI, BirdTransform.position, Quaternion.identity);
                                Destroy(h, 5);
                            }
                            c0 = false;
                        }
                    }
                }


                if (a >= 40) Slider.value = a;



                if (a >= 45)
                {
                    Sld.SetActive(false);
                    if (b == 2 && bb == 3)
                    {
                        PlayerPrefs.SetInt("SaveTubeColor", 1);
                        n1 = true;

                        if (PlayerPrefs.GetInt("SaveMMX") == 1) PlayerPrefs.SetInt("SaveMMX", 2);
                        else PlayerPrefs.SetInt("SaveMMX", PlayerPrefs.GetInt("SaveMMX") + 2);
                        //GameObject q = Instantiate(TextTN, BirdTransform.position, Quaternion.identity);
                        //Destroy(q, 5);
                    }
                    if (b == 1 && bb == 3)
                    {
                        BI.enabled = true;
                        BI.On = true;
                        BI.Check = false;
                        BL2.Inver2 = true;
                        n2 = true;
                        n22 = true;
                        PlayerPrefs.SetInt("SaveBI", 1);

                        if (PlayerPrefs.GetInt("SaveMMX") == 1) PlayerPrefs.SetInt("SaveMMX", 2);
                        else PlayerPrefs.SetInt("SaveMMX", PlayerPrefs.GetInt("SaveMMX") + 2);
                        //GameObject q = Instantiate(TextBI, BirdTransform.position, Quaternion.identity);
                        //Destroy(q, 5);
                    }
                    if (b == 0 && bb == 3)
                    {
                        CI.enabled = true;
                        CI.On = true;
                        CI.Check = false;
                        BL2.Inver = true;
                        n3 = true;
                        n32 = true;
                        PlayerPrefs.SetInt("SaveCI", 1);

                        if (PlayerPrefs.GetInt("SaveMMX") == 1) PlayerPrefs.SetInt("SaveMMX", 2);
                        else PlayerPrefs.SetInt("SaveMMX", PlayerPrefs.GetInt("SaveMMX") + 2);
                        //GameObject q = Instantiate(TextCI, BirdTransform.position, Quaternion.identity);
                        //Destroy(q, 5);
                    }


                    //if (n1 && n2 && n3)
                    //{
                    //PlayerPrefs.SetInt("SaveMMX", 6);
                    //act = false;
                    //MM.enabled = false;
                    //bb = 2;
                    //}


                    //


                    if (b == 1 && bb == 2 && !n22)
                    {
                        BirdInvers_On();

                        //PlayerPrefs.SetInt("SaveMMX", PlayerPrefs.GetInt("SaveMMX") + 2);
                        //GameObject q = Instantiate(TextBI, BirdTransform.position, Quaternion.identity);
                        //Destroy(q, 5);
                    }
                    else
                    {
                        if (b == 1 && bb == 2 && n22)
                        {
                            BirdInvers_Off();

                            //BNI.enabled = true;
                            //PlayerPrefs.SetInt("SaveMMX", PlayerPrefs.GetInt("SaveMMX") + 2);
                            //GameObject q = Instantiate(TextBI, BirdTransform.position, Quaternion.identity);
                            //Destroy(q, 5);
                        }
                    }
                    if (b == 0 && bb == 2 && !n32)
                    {
                        CameraInvers_On();

                        //PlayerPrefs.SetInt("SaveMMX", PlayerPrefs.GetInt("SaveMMX") + 2);
                        //GameObject q = Instantiate(TextCI, BirdTransform.position, Quaternion.identity);
                        //Destroy(q, 5);
                    }
                    else
                    {
                        if (b == 0 && bb == 2 && n32)
                        {
                            CameraInvers_Off();

                            //CNI.enabled = true;
                            //PlayerPrefs.SetInt("SaveMMX", PlayerPrefs.GetInt("SaveMMX") + 2);
                            //GameObject q = Instantiate(TextCI, BirdTransform.position, Quaternion.identity);
                            //Destroy(q, 5);
                        }
                    }
                    //

                    //

                    if (n1 && n2 && n3)
                    {
                        //PlayerPrefs.SetInt("SaveMMX", 6);
                        //act = false;
                        //MM.enabled = false;
                        bb = 2;
                    }

                    a = 40;
                    C123_True();
                }
            }

        }
    }

    public void BirdInvers_On()
    {
        BI.On = true;
        BI.Check = false;
        //BNI.enabled = false;
        BL2.Inver2 = true;
        n22 = true;
        PlayerPrefs.SetInt("SaveBI", 3);
    }

    public void BirdInvers_Off()
    {
        BI.On = false;
        BI.Check = false;
        BL2.Inver2 = false;
        n22 = false;
        PlayerPrefs.SetInt("SaveBI", 2);
    }

    public void CameraInvers_On()
    {
        CI.On = true;
        CI.Check = false;
        //CNI.enabled = false;
        BL2.Inver = true;
        n32 = true;
        PlayerPrefs.SetInt("SaveCI", 3);
    }

    public void CameraInvers_Off()
    {
        CI.On = false;
        CI.Check = false;
        BL2.Inver = false;
        n32 = false;
        PlayerPrefs.SetInt("SaveCI", 2);
    }

    public void C123_True()
    {
        c0 = true;
        c1 = true;
        c2 = true;
        c3 = true;
    }
}
