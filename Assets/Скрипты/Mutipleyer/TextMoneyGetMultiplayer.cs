using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMoneyGetMultiplayer : MonoBehaviour
{
    public TextMeshPro Money, Money2, Money3;
    // Start is called before the first frame update
    void Start()
    {
        Money.SetText("+" + PlayerPrefs.GetInt("SaveMoneyText"));
        Money2.SetText("" + PlayerPrefs.GetString("SaveMoneyTextString"));
        Money3.SetText("x" + PlayerPrefs.GetFloat("SaveMoneyTextFloat"));
    }
}
