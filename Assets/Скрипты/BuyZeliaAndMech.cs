using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyZeliaAndMech : MonoBehaviour
{
    public int VodopadCount = 50000, OblakoCount = 50000, MechCount = 50000, ToporCount = 50000;
    public bool Vodopad, Oblako, Mech, Topor;
    public GameObject Vodopad_True, Oblako_True, Mech_True, Topor_True;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("SaveVodopadBuy") == 1) 
        {
            Vodopad = true;
            Vodopad_True.SetActive(true);
        }
        if (PlayerPrefs.GetInt("SaveOblakoBuy") == 1)
        {
            Oblako = true;
            Oblako_True.SetActive(true);
        }
        if (PlayerPrefs.GetInt("SaveMechBuy") == 1)
        {
            Mech = true;
            Mech_True.SetActive(true);
        }
        if (PlayerPrefs.GetInt("SaveToporBuy") == 1)
        {
            Topor = true;
            Topor_True.SetActive(true);
        }
    }

    public void VodopadBuy()
    {
        if (PlayerPrefs.GetInt("SaveMoney") > VodopadCount && !Vodopad)
        {
            PlayerPrefs.SetInt("SaveMoney", PlayerPrefs.GetInt("SaveMoney") - VodopadCount);
            PlayerPrefs.SetInt("SaveVodopadBuy", 1);
            Vodopad_True.SetActive(true);
        }
    }

    public void OblakoBuy()
    {
        if (PlayerPrefs.GetInt("SaveMoney") > OblakoCount && !Oblako)
        {
            PlayerPrefs.SetInt("SaveMoney", PlayerPrefs.GetInt("SaveMoney") - OblakoCount);
            PlayerPrefs.SetInt("SaveOblakoBuy", 1);
            Oblako_True.SetActive(true);
        }
    }

    public void MechBuy()
    {
        if (PlayerPrefs.GetInt("SaveMoney") > MechCount && !Mech)
        {
            PlayerPrefs.SetInt("SaveMoney", PlayerPrefs.GetInt("SaveMoney") - MechCount);
            PlayerPrefs.SetInt("SaveMechBuy", 1);
            Mech_True.SetActive(true);
        }
    }

    public void ToporBuy()
    {
        if (PlayerPrefs.GetInt("SaveMoney") > ToporCount && !Topor)
        {
            PlayerPrefs.SetInt("SaveMoney", PlayerPrefs.GetInt("SaveMoney") - ToporCount);
            PlayerPrefs.SetInt("SaveToporBuy", 1);
            Topor_True.SetActive(true);
        }
    }

    public void Off_All()
    {
        if (PlayerPrefs.GetInt("SaveVodopadBuy") == 1)
        {
            PlayerPrefs.SetInt("SaveVodopadBuy", 0);
            Vodopad_True.SetActive(false);
            PlayerPrefs.SetInt("SaveMoney", PlayerPrefs.GetInt("SaveMoney") + 100);
        }
        if (PlayerPrefs.GetInt("SaveOblakoBuy") == 1)
        {
            PlayerPrefs.SetInt("SaveOblakoBuy", 0);
            Oblako_True.SetActive(false);
            PlayerPrefs.SetInt("SaveMoney", PlayerPrefs.GetInt("SaveMoney") + 100);
        }
        if (PlayerPrefs.GetInt("SaveMechBuy") == 1)
        {
            PlayerPrefs.SetInt("SaveMechBuy", 0);
            Mech_True.SetActive(false);
            PlayerPrefs.SetInt("SaveMoney", PlayerPrefs.GetInt("SaveMoney") + 100);
        }
        if (PlayerPrefs.GetInt("SaveToporBuy") == 1)
        {
            PlayerPrefs.SetInt("SaveToporBuy", 0);
            Topor_True.SetActive(false);
            PlayerPrefs.SetInt("SaveMoney", PlayerPrefs.GetInt("SaveMoney") + 100);
        }
    }
}
