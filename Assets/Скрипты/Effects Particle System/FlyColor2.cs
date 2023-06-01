using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyColor2 : MonoBehaviour
{
    public ParticleSystem PS2;
    // Start is called before the first frame update
    void Start()
    {
        PS2.startColor = new Color(PlayerPrefs.GetFloat("SaveBColorR"), PlayerPrefs.GetFloat("SaveBColorG"), PlayerPrefs.GetFloat("SaveBColorB"), 1);
    }
}
