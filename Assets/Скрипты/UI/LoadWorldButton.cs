using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWorldButton : MonoBehaviour
{
    public GameObject[] a;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("SaveintSloshnost") == 0) PlayerPrefs.SetInt("SaveintSloshnost", 1);
        a[PlayerPrefs.GetInt("SaveintSloshnost")-1].SetActive(true);
    }
}
