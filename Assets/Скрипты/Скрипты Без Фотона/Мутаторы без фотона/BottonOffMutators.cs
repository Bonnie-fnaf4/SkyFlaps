using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottonOffMutators : MonoBehaviour
{
    public GameObject OffObject, OffObject2;
    void Start()
    {
        if (PlayerPrefs.GetInt("SaveMutatorInt") == 1)
        {
            OffObject.SetActive(true);
            OffObject2.SetActive(true);
        }
    }
    public void On()
    {
        PlayerPrefs.SetInt("SaveMutatorInt", 1);
        OffObject.SetActive(true);
        OffObject2.SetActive(true);
    }
    public void Off()
    {
        PlayerPrefs.SetInt("SaveMutatorInt", 0);
        OffObject.SetActive(false);
        OffObject2.SetActive(false);
    }
}
