using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeColor : MonoBehaviour
{
    public SpriteRenderer c;
    public Color a;
    public float r, g, b;// Timer;
    public TubeColor TC;
    // Start is called before the first frame update
    void Start()
    {
        TC = GetComponent<TubeColor>();
        if (PlayerPrefs.GetInt("SaveTubeColor") == 0) TC.enabled = false;
        else
        {
            r = 0.40f;
            g = 0.40f;
            b = 0.40f;
            c = GetComponent<SpriteRenderer>();
            a = new Color(r, g, b, b);
            c.color = a;
        }
    }

}
