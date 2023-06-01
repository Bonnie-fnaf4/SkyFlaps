using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMoneyGet : MonoBehaviour
{
    public TextMeshPro Money, Money2, Money3;
    public float a, b;
    public int all;
    // Start is called before the first frame update
    void Start()
    {
        a = PlayerPrefs.GetInt("SaveMoneyText");
        //a = PlayerPrefs.GetInt("SaveMMX");
        b = PlayerPrefs.GetFloat("SaveTimeB");
        b = b * PlayerPrefs.GetInt("SaveMMX");
        all = (int)(a * b);
        if (a == 0)
        {
            Money.SetText("");
            Money2.SetText("");
            Money3.SetText("");
            return;
        }
        Money.SetText("+" + all);
        if (b == 1)
        {
            Money2.SetText("");
            Money3.SetText("");
        }
        else
        {
            Money2.SetText("x" + b.ToString("0.00"));
            Money3.SetText("+" + a);
        }
    }
}
