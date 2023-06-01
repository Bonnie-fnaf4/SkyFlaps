using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oblako : MonoBehaviour
{
    private ParticleSystem ob;
    float a = 10f;
    // Start is called before the first frame update
    void Start()
    {
        a = PlayerPrefs.GetFloat("SaveOblakotime");
        a = a - 1f;
        ob = GetComponent<ParticleSystem>();
        ob.Stop(); 
        var main = ob.main;
        main.duration = a;

        ob.Play();
    }
}
