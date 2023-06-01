using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueParticle : MonoBehaviour
{
    int Blue;
    public GameObject BlueParticleSystem;
    // Update is called once per frame
    void Update()
    {
        Blue = PlayerPrefs.GetInt("SaveintBlue");
        if (Blue == 1) BlueParticleSystem.SetActive(true);
        if (Blue == 0) BlueParticleSystem.SetActive(false);
    }
}
