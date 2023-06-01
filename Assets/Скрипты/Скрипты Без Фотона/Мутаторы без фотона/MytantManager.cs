using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MytantManager : MonoBehaviour
{
    public GameObject Number1, Number2, Number3;
    public GameObject TextCI, TextBI, TextTN;
    public GameObject Sld;
    public Slider Slider;

    public CameraInversia CI;
    public BirdInversion BI;

    //public CameraNotInversia CNI;
    //public BirdNotInversion BNI;

    public BirdControl2 BL2;
    public GameObject Bird;
    public Transform BirdTransform;
    public float a = 0, f = 0, ff = 90;
    //a - Таймер который запускает
    //алгоритм включения мутаторов. 
    //С помощью слайдера и Number1 2 3,
    //сигнализирует о запуске мутатора

    //f - Таймер для запуска таймера а
    //ff - Граница запуска таймера f
    public int b = 0, bb = 0;
    //b - Id мутатора которого нужно запустить
    //bb - Максимульный допустимый id мутаторов
    public int checkMMX = 1;
    public bool c0 = true, c1 = true, c2 = true, c3 = true;
    //Переменные для таймера
    public bool n1 = false, n2 = false, n3 = false;

    public bool n32 = false, n22 = false;
    public bool act = true, start = true;

    public MytantManager MM;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent_Mytators_And_Start_bb_MMX_Set();
        //Первая часть включение скриптов
        Step_First_Start_Mytators();

        //Вторая часть включения скриптов
        Step_Second_Start_Mytators();
        //
        Step_On_MMX_In_Start_And_15x_Start();
        //a = 40;
        //f = 90;
    }

    // Update is called once per frame
    void Update()
    {
        //if (PlayerPrefs.GetInt("SaveMutatorInt") == 1) MM.enabled = false;
        if (start) f += Time.deltaTime;
        if (f >= ff)
        {
            Mytator_Give_And_Effects_Set();

            if (a >= 40) Slider.value = a;

            Mytators_On();
        }

    }

    public void GetComponent_Mytators_And_Start_bb_MMX_Set()
    {
        BI = Bird.GetComponent<BirdInversion>();
        BL2 = Bird.GetComponent<BirdControl2>();
        //BNI = Bird.GetComponent<BirdNotInversion>();
        CI = GetComponent<CameraInversia>();
        //CNI = GetComponent<CameraNotInversia>();
        MM = GetComponent<MytantManager>();

        bb = 3;
        //BI.enabled = true;
        PlayerPrefs.SetInt("SaveMMX", checkMMX);
    }
    public void Step_First_Start_Mytators()
    {
        if (PlayerPrefs.GetInt("SaveTubeColor") == 1)
        {
            f = 90;
            n1 = true;
            checkMMX = 2;
            PlayerPrefs.SetInt("SaveMMX", checkMMX);
        }
        if (PlayerPrefs.GetInt("SaveCI") == 1)
        {
            CI.enabled = true;
            CI.On = true;
            CI.Check = false;
            BL2.Inver = true;
            n3 = true;
            n32 = true;
            f = 90;
            if (n1) checkMMX = 4;
            else checkMMX = 2;
            PlayerPrefs.SetInt("SaveMMX", checkMMX);
        }
        if (PlayerPrefs.GetInt("SaveBI") == 1)
        {
            n2 = true;
            n22 = true;
            BI.enabled = true;
            BI.On = true;
            BI.Check = false;
            BL2.Inver2 = true;
            f = 90;
            if (n1)
            {
                if (n3) checkMMX = 6;
                else checkMMX = 4;
            }
            else
            {
                if (n3) checkMMX = 4;
                else checkMMX = 2;
            }
            PlayerPrefs.SetInt("SaveMMX", checkMMX);

        }
    }

    public void Step_Second_Start_Mytators()
    {
        if (PlayerPrefs.GetInt("SaveCI") == 2)
        {
            CI.enabled = true;
            CI.On = false;
            CI.Check = false;
            BL2.Inver = false;
            n32 = false;
            n3 = true;
            f = 90;
            if (n1) checkMMX = 4;
            else checkMMX = 2;
            PlayerPrefs.SetInt("SaveMMX", checkMMX);
        }
        if (PlayerPrefs.GetInt("SaveBI") == 2)
        {
            BI.enabled = true;
            BI.On = false;
            BI.Check = true;
            BL2.Inver2 = false;
            n22 = false;
            n2 = true;
            f = 90;
            if (n1)
            {
                if (n3) checkMMX = 6;
                else checkMMX = 4;
            }
            else
            {
                if (n3) checkMMX = 4;
                else checkMMX = 2;
            }
            PlayerPrefs.SetInt("SaveMMX", checkMMX);
        }
        //
        if (PlayerPrefs.GetInt("SaveCI") == 3)
        {
            CI.enabled = true;
            CI.On = true;
            CI.Check = false;
            BL2.Inver = true;
            n32 = true;
            n3 = true;
            f = 90;
            if (n1) checkMMX = 4;
            else checkMMX = 2;
            PlayerPrefs.SetInt("SaveMMX", checkMMX);
        }
        if (PlayerPrefs.GetInt("SaveBI") == 3)
        {
            BI.enabled = true;
            BI.On = true;
            BI.Check = false;
            BL2.Inver2 = true;
            n22 = true;
            n2 = true;
            f = 90;
            if (n1)
            {
                if (n3) checkMMX = 6;
                else checkMMX = 4;
            }
            else
            {
                if (n3) checkMMX = 4;
                else checkMMX = 2;
            }
            PlayerPrefs.SetInt("SaveMMX", checkMMX);
        }
    }

    public void Step_On_MMX_In_Start_And_15x_Start()
    {
        if (n1 && n2 && n3)
        {
            //act = false;
            bb = 2;
            //MM.enabled = false;
            PlayerPrefs.SetInt("SaveMMX", 6);
        }

        if (PlayerPrefs.GetInt("SaveSetting1.5x") == 1) ff = 10;
        else ff = 90;
        //f = 90;
        //a = 40;
    }

    public void Mytator_Give_And_Effects_Set()
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

                    B_BB_Random();

                    Text_Set();

                    c0 = false;
                }
            }
        }
    }

    public void B_BB_Random()
    {
        b = Random.Range(0, 3);
        if (!(n3 && n2 && n1))
            while ((n3 && b == 0) || (n2 && b == 1) || (n1 && b == 2) || (bb == 2)) b = Random.Range(0, bb);

        if (bb == 2) b = Random.Range(0, bb);
    }

    public void Text_Set()
    {

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
    }

    public void Mytators_On()
    {
        if (a >= 45)
        {
            Sld.SetActive(false);
            if (b == 2 && bb == 3)
            {
                Tube_On();
            }
            if (b == 1 && bb == 3)
            {
                Bird_Invers_On_First();
            }
            if (b == 0 && bb == 3)
            {
                Camera_Invers_On_Fisrt();
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
                Bird_Invers_On_Second();
            }
            else
            {
                if (b == 1 && bb == 2 && n22)
                {
                    Bird_Invers_Off();
                }
            }
            if (b == 0 && bb == 2 && !n32)
            {
                Camera_Invers_On_Second();
            }
            else
            {
                if (b == 0 && bb == 2 && n32)
                {
                    Camera_Invers_Off();
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

            a = 0;
            c0 = true;
            c1 = true;
            c2 = true;
            c3 = true;
        }
    }

    public void Tube_On()
    {
        PlayerPrefs.SetInt("SaveTubeColor", 1);
        n1 = true;

        if (PlayerPrefs.GetInt("SaveMMX") == 1) PlayerPrefs.SetInt("SaveMMX", 2);
        else PlayerPrefs.SetInt("SaveMMX", PlayerPrefs.GetInt("SaveMMX") + 2);
        //GameObject q = Instantiate(TextTN, BirdTransform.position, Quaternion.identity);
        //Destroy(q, 5);
    }

    public void Bird_Invers_On_First()
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

    public void Camera_Invers_On_Fisrt()
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

    //Циклические включения и выключения

    public void Bird_Invers_On_Second()
    {
        BI.On = true;
        BI.Check = false;
        //BNI.enabled = false;
        BL2.Inver2 = true;
        n22 = true;
        PlayerPrefs.SetInt("SaveBI", 3);
        //PlayerPrefs.SetInt("SaveMMX", PlayerPrefs.GetInt("SaveMMX") + 2);
        //GameObject q = Instantiate(TextBI, BirdTransform.position, Quaternion.identity);
        //Destroy(q, 5);
    }

    public void Bird_Invers_Off()
    {
        //BNI.enabled = true;
        BI.On = false;
        BI.Check = false;
        BL2.Inver2 = false;
        n22 = false;
        PlayerPrefs.SetInt("SaveBI", 2);
        //PlayerPrefs.SetInt("SaveMMX", PlayerPrefs.GetInt("SaveMMX") + 2);
        //GameObject q = Instantiate(TextBI, BirdTransform.position, Quaternion.identity);
        //Destroy(q, 5);
    }

    public void Camera_Invers_On_Second()
    {
        CI.On = true;
        CI.Check = false;
        //CNI.enabled = false;
        BL2.Inver = true;
        n32 = true;
        PlayerPrefs.SetInt("SaveCI", 3);
        //PlayerPrefs.SetInt("SaveMMX", PlayerPrefs.GetInt("SaveMMX") + 2);
        //GameObject q = Instantiate(TextCI, BirdTransform.position, Quaternion.identity);
        //Destroy(q, 5);
    }

    public void Camera_Invers_Off()
    {
        //CNI.enabled = true;
        CI.On = false;
        CI.Check = false;
        BL2.Inver = false;
        n32 = false;
        PlayerPrefs.SetInt("SaveCI", 2);
        //PlayerPrefs.SetInt("SaveMMX", PlayerPrefs.GetInt("SaveMMX") + 2);
        //GameObject q = Instantiate(TextCI, BirdTransform.position, Quaternion.identity);
        //Destroy(q, 5);
    }
}