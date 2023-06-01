using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vodopad : MonoBehaviour
{
    private ParticleSystem vo;
    float a = 1f;
    // Start is called before the first frame update
    void Start()
    {
        a = PlayerPrefs.GetFloat("SaveVodopadtime");
        a = a - 1f;
        vo = GetComponent<ParticleSystem>();
        vo.Stop(); // Cannot set duration whilst particle system is playing

        var main = vo.main;
        main.duration = a;

        vo.Play();
    }
}
