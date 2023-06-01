using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyColor : MonoBehaviour
{
    public ParticleSystem PS;
    public Color a;
    public float TimeB = 0;
    public float ColorR = 0;
    public float ColorG = 0;
    // Start is called before the first frame update
    void Start()
    {
        //PS = GetComponent<ParticleSystem>();
        TimeB = PlayerPrefs.GetFloat("SaveTimeB");
        if (TimeB <= 1.5)
        {
            ColorR = (TimeB - 1) * 2;
            a = new Color(ColorR, 1f, 0, 1);
        }
        if (TimeB >= 1.5)
        {
            ColorR = 1;
            ColorG = (TimeB - 1.5f) * 2;
            a = new Color(ColorR, 1 - ColorG, 0, 1);
        }
        PS.startColor = a;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
