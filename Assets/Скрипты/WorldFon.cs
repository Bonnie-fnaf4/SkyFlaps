using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldFon : MonoBehaviour
{
    public GameObject[] Fon = new GameObject[10];
    int SL;
    void Start()
    {
        SL = PlayerPrefs.GetInt("SaveintSloshnost");
        if (SL <= 0) SL = Random.RandomRange(1, PlayerPrefs.GetInt("SaveSL"));
        Fon[SL - 1].SetActive(true);
    }
}
