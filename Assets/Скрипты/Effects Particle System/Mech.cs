using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech : MonoBehaviour
{
    private ParticleSystem vo;
    float a = 1f;
    // Start is called before the first frame update
    void Start()
    {
        a = PlayerPrefs.GetFloat("SaveMechtime");
        a = a - 0.5f;
        vo = GetComponent<ParticleSystem>();
        vo.Stop(); // Cannot set duration whilst particle system is playing

        var main = vo.main;
        main.duration = a;

        vo.Play();
    }
}
