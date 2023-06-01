using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ColorSetting : MonoBehaviour
{
    public Slider RS, GS, BS;

    public Color SS, LoadColor;

    public Color[] RC = new Color[6];
    public Color[] GC = new Color[6];
    public Color[] BC = new Color[6];


    public float r, g, b;

    public InputField Rtext, Gtext, Btext;

    public float Rtxt, Gtxt, Btxt;

    public float CheckR, CheckG, CheckB;

    public float r1, g1, b1;
    public float SaveColor, SC;

    public Image ColorSelect;

    public Image[] RI = new Image[6];
    public Image[] GI = new Image[6];
    public Image[] BI = new Image[6];
    public float colorfloat;

    public Image[] S, VO, DP, B;
    public GameObject Sob, VOob, DPob, Bob;
    public bool Bbool;

    // Start is called before the first frame update
    void Start()
    {
        //r = 0.4f;
        //g = 0.8f;
        //b = 0.5f;
        //SaveColor = r + 100 * g + 10000 * b;
        if (PlayerPrefs.GetInt("SaveBBoolColor") == 1) Bbool = true;
        r = PlayerPrefs.GetFloat("SaveSColorR");
        g = PlayerPrefs.GetFloat("SaveSColorG");
        b = PlayerPrefs.GetFloat("SaveSColorB");
        for (int i = 0; i < S.Length; i++) S[i].color = new Color(r, g, b, 1);

        r = PlayerPrefs.GetFloat("SaveVOColorR");
        g = PlayerPrefs.GetFloat("SaveVOColorG");
        b = PlayerPrefs.GetFloat("SaveVOColorB");
        for (int i = 0; i < VO.Length; i++) VO[i].color = new Color(r, g, b, 1);

        r = PlayerPrefs.GetFloat("SaveDPColorR");
        g = PlayerPrefs.GetFloat("SaveDPColorG");
        b = PlayerPrefs.GetFloat("SaveDPColorB");
        for (int i = 0; i < DP.Length; i++) DP[i].color = new Color(r, g, b, 1);

        if (PlayerPrefs.GetFloat("SaveNewGame") == 1)
        {

            B[0].color = new Color(PlayerPrefs.GetFloat("SaveBColorR"), PlayerPrefs.GetFloat("SaveBColorG"), PlayerPrefs.GetFloat("SaveBColorB"), 1);


            if (Bbool) B[1].color = new Color(PlayerPrefs.GetFloat("SaveVOColorR"), PlayerPrefs.GetFloat("SaveVOColorG"), PlayerPrefs.GetFloat("SaveVOColorB"), 1);
            else B[1].color = new Color(PlayerPrefs.GetFloat("SaveBColorR"), PlayerPrefs.GetFloat("SaveBColorG"), PlayerPrefs.GetFloat("SaveBColorB"), 1);
        }
        else
        {
            PlayerPrefs.SetFloat("SaveBColorR", 1);
            PlayerPrefs.SetFloat("SaveBColorG", 1);
            PlayerPrefs.SetFloat("SaveBColorB", 1);

            PlayerPrefs.SetFloat("SaveSColorR", 1);
            PlayerPrefs.SetFloat("SaveSColorG", 1);
            PlayerPrefs.SetFloat("SaveSColorB", 1);

            PlayerPrefs.SetFloat("SaveVOColorR", 1);
            PlayerPrefs.SetFloat("SaveVOColorG", 1);
            PlayerPrefs.SetFloat("SaveVOColorB", 1);

            PlayerPrefs.SetFloat("SaveDPColorR", 1);
            PlayerPrefs.SetFloat("SaveDPColorG", 1);
            PlayerPrefs.SetFloat("SaveDPColorB", 1);

            PlayerPrefs.SetFloat("SaveNewGame", 1);

            B[0].color = new Color(PlayerPrefs.GetFloat("SaveBColorR"), PlayerPrefs.GetFloat("SaveBColorG"), PlayerPrefs.GetFloat("SaveBColorB"), 1);
            B[1].color = new Color(PlayerPrefs.GetFloat("SaveBColorR"), PlayerPrefs.GetFloat("SaveBColorG"), PlayerPrefs.GetFloat("SaveBColorB"), 1);
        }
    }

    public void InputColor()
    {
        float.TryParse(Rtext.text, out Rtxt);
        float.TryParse(Gtext.text, out Gtxt);
        float.TryParse(Btext.text, out Btxt);

        if (!(Rtxt == RS.value))
        {
            RS.value = Rtxt;
        }
        if (!(Gtxt == GS.value))
        {
            GS.value = Gtxt;
        }
        if (!(Rtxt == RS.value))
        {
            BS.value = Btxt;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //float.TryParse(Rtext.text, out Rtxt);
        //float.TryParse(Gtext.text, out Gtxt);
        //float.TryParse(Btext.text, out Btxt);

        //if (!(Rtxt == r) && !(Rtext.text == null)) r = Rtxt;
        //if (!(Gtxt == g) && !(Gtext.text == null)) g = Gtxt;
        //if (!(Btxt == b) && !(Btext.text == null)) b = Btxt;
        if (!(r == RS.value) || !(g == GS.value) || !(b == BS.value))
        {

            r = RS.value;
            g = GS.value;
            b = BS.value;


            Rtext.text = "" + r.ToString("0.000");
            Gtext.text = "" + g.ToString("0.000");
            Btext.text = "" + b.ToString("0.000");

        }
        //if (r == CheckR && g == CheckG && b == CheckB)
        //{

        //}
        //else
        //{
        CheckR = r;
            CheckB = b;
            CheckG = g;
            SS = new Color(r, g, b, 1);
            colorfloat = 0;
            for (int i = 0; i < RC.Length; i++)
            {
                RC[i] = new Color(colorfloat, g, b, 1);
                GC[i] = new Color(r, colorfloat, b, 1);
                BC[i] = new Color(r, g, colorfloat, 1);
                colorfloat += 0.20f;
                RI[i].color = RC[i];
                GI[i].color = GC[i];
                BI[i].color = BC[i];
            }

            ColorSelect.color = SS;

            if (Sob.activeSelf  == true) for (int i = 0; i < S.Length;  i++) S[i].color  = SS;

            if (VOob.activeSelf == true) for (int i = 0; i < VO.Length; i++)
                {
                    VO[i].color = SS;
                    if(Bbool)B[1].color = SS;
                }

            if (DPob.activeSelf == true) for (int i = 0; i < DP.Length; i++) DP[i].color = SS;
            if (Bob.activeSelf == true)
            {
                B[0].color = SS;
                if (!Bbool) B[1].color = SS;
            }

        if (Sob.activeSelf == true)
        {
            PlayerPrefs.SetFloat("SaveSColorR",  r);
            PlayerPrefs.SetFloat("SaveSColorG",  g);
            PlayerPrefs.SetFloat("SaveSColorB",  b);
        }

        if (VOob.activeSelf == true)
        {
            PlayerPrefs.SetFloat("SaveVOColorR", r);
            PlayerPrefs.SetFloat("SaveVOColorG", g);
            PlayerPrefs.SetFloat("SaveVOColorB", b);
        }

        if (DPob.activeSelf == true)
        {
            PlayerPrefs.SetFloat("SaveDPColorR", r);
            PlayerPrefs.SetFloat("SaveDPColorG", g);
            PlayerPrefs.SetFloat("SaveDPColorB", b);
        }

        if (Bob.activeSelf == true)
        {
            PlayerPrefs.SetFloat("SaveBColorR", r);
            PlayerPrefs.SetFloat("SaveBColorG", g);
            PlayerPrefs.SetFloat("SaveBColorB", b);
        }
        //SaveColor = r + 100 * g + 10000 * b;
        ///if (Sob.activeSelf  == true) PlayerPrefs.SetFloat("SaveSColor",  SaveColor);
        ///if (VOob.activeSelf == true) PlayerPrefs.SetFloat("SaveVOColor", SaveColor);
        ///if (DPob.activeSelf == true) PlayerPrefs.SetFloat("SaveDPColor", SaveColor);
        ///if (Bob.activeSelf  == true) PlayerPrefs.SetFloat("SaveBColor",  SaveColor);

        //r1 = SaveColor - 100 * g - 10000 * b;
        //g1 = (SaveColor - r - 10000 * b) / 100;
        //b1 = (SaveColor - r - 100 * g) / 10000;
        //LoadColor = new Color(r1, g1, b1, 1);
        //}
    }

    public void BboolTrue()
    {
        Bbool = true;
        PlayerPrefs.SetInt("SaveBBoolColor", 1);
    }
    public void BboolFalse()
    {
        Bbool = false;
        PlayerPrefs.SetInt("SaveBBoolColor", 0);
    }
    public void ValueSet()
    {
        //if (Sob.activeSelf  == true) SC = PlayerPrefs.GetFloat("SaveSColor" );
        //if (VOob.activeSelf == true) SC = PlayerPrefs.GetFloat("SaveVOColor");
        //if (DPob.activeSelf == true) SC = PlayerPrefs.GetFloat("SaveDPColor");
        //if (Bob.activeSelf  == true) SC = PlayerPrefs.GetFloat("SaveBColor" );
        //b1 = (float)Math.Round(SC/10000,2);
        //g1 = (SC - r - 10000 * b) / 100;
        //r1 = (SC - r - 100 * g) / 10000;
        if (Sob.activeSelf == true)
        {
            r1 = PlayerPrefs.GetFloat("SaveSColorR");
            g1 = PlayerPrefs.GetFloat("SaveSColorG");
            b1 = PlayerPrefs.GetFloat("SaveSColorB");
        }

        if (VOob.activeSelf == true)
        {
            r1 = PlayerPrefs.GetFloat("SaveVOColorR");
            g1 = PlayerPrefs.GetFloat("SaveVOColorG");
            b1 = PlayerPrefs.GetFloat("SaveVOColorB");
        }

        if (DPob.activeSelf == true)
        {
            r1 = PlayerPrefs.GetFloat("SaveDPColorR");
            g1 = PlayerPrefs.GetFloat("SaveDPColorG");
            b1 = PlayerPrefs.GetFloat("SaveDPColorB");
        }

        if (Bob.activeSelf == true)
        {
            r1 = PlayerPrefs.GetFloat("SaveBColorR");
            g1 = PlayerPrefs.GetFloat("SaveBColorG");
            b1 = PlayerPrefs.GetFloat("SaveBColorB");
        }
        RS.value = r1;
        GS.value = g1;
        BS.value = b1;
    }
}