using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiButtonOffOn : MonoBehaviour
{
    public GameObject[] All;
    // Update is called once per frame
    public void On()
    {
        for (int i = 0; i < All.Length; i++)
        {
            All[i].SetActive(true);
        }
    }
    public void Off()
    {
        for (int i = 0; i < All.Length; i++)
        {
            All[i].SetActive(false);
        }
    }
}
