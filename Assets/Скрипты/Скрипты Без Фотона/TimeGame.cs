using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeGame : MonoBehaviour
{
    float a = 0, b = 1;
    bool d = false, g = true, f = true, h = true; // d - Это тригер началась ли игра что бы потом запустить таймер на переменной а
    // g - Это тригер для отключения добавления к "а" времени // f - Это тригер который срабатывает 1 раз и символизирует конец первого периода. Нужен для разового обнуления "а"
    // h - Это переменная для выключения скрипта для экономии ресурсов
    public Text c;
    TimeGame TimeGameScript;
    // Start is called before the first frame update
    void Start()
    {
        b = PlayerPrefs.GetFloat("SaveTimeB");
        if (b < 1.4f) { if (PlayerPrefs.GetInt("SaveSetting1.5x") == 1) 
            {
                b = 1.5f;
                PlayerPrefs.SetFloat("SaveTimeB", b);
            } }

        TimeGameScript = GetComponent<TimeGame>();
        Time.timeScale = b;
        //PlayerPrefs.SetFloat("SaveTimeB", 0);
        PlayerPrefs.SetInt("SaveSG", 0);

        if (b >= 1.5)
        {
            if (PlayerPrefs.GetInt("SaveSetting1.5x") == 2) g = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!h) TimeGameScript.enabled = false;

        if (d == false) { if (PlayerPrefs.GetInt("SaveSG") == 1) d = true; }

        else
        {
            //Для каждого этапа изменения времени есть свои if для проверки прогреесса
            a_Plus_Time();

            Step_First();

            Step_Second();

            c.text = "b = " + b + " a = " + a + " d = " + d + " g = " + g + " f = " + f + " h = " + h;

            Off_a_Plus_Time_First();

            Off_a_Plus_Time_Second();
        }
    }

    public void Set_Time()
    {
        g = false;
        Time.timeScale = b;
        PlayerPrefs.SetFloat("SaveTimeB", b);
        if (b <= 1.3) PlayerPrefs.SetFloat("SaveB", b);
    }

    public void a_Plus_Time()
    {
        if (g && !(Time.timeScale == 0)) a += Time.deltaTime;
    }

    public void Step_First()
    {
        if (a >= 30 && !(Time.timeScale == 0) && b <= 1.5)
        {
            b += Time.deltaTime / 120;
            Set_Time();
        }
    }

    public void Step_Second()
    {
        if (a >= 90 && !(Time.timeScale == 0) && b >= 1.5)
        {
            b += Time.deltaTime / 240;
            Set_Time();
        }
    }

    public void Off_a_Plus_Time_First()
    {
        if (b > 1.5 && f)
        {
            PlayerPrefs.SetFloat("SaveTimeB", b);
            f = false;
            a = 0;
            if (!(PlayerPrefs.GetInt("SaveSetting1.5x") == 2)) g = true;
        }
    }

    public void Off_a_Plus_Time_Second()
    {
        if (b >= 2 && !f)
        {
            h = false;
            b = 2;
            Time.timeScale = b;
            PlayerPrefs.SetFloat("SaveTimeB", b);
        }
    }
}
