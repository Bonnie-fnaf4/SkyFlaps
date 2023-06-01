using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSetting : MonoBehaviour
{
    public GameObject up, down;
    void Start()
    {
        if (PlayerPrefs.GetInt("SaveSetting1.5x") == 1) up.SetActive(true);
        if (PlayerPrefs.GetInt("SaveSetting1.5x") == 2) down.SetActive(true);
    }
    public void EnbUp()
    {
        PlayerPrefs.SetInt("SaveSetting1.5x", 1);
        up.SetActive(true);
        down.SetActive(false);
    }
    public void EnbDown()
    {
        PlayerPrefs.SetInt("SaveSetting1.5x", 2);
        down.SetActive(true);
        up.SetActive(false);
    }
    public void DisUp()
    {
        down.SetActive(false);
        PlayerPrefs.SetInt("SaveSetting1.5x", 0);
        up.SetActive(false);
    }
    public void DisDown()
    {
        up.SetActive(false);
        PlayerPrefs.SetInt("SaveSetting1.5x", 0);
        down.SetActive(false);
    }
}
