using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelect : MonoBehaviour
{
    public GameObject[] a;
    public int Myint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {
        for (int i = 0; i < a.Length; i++)
        {
            if (Myint == i) a[i].active = true;
            else a[i].active = false;
        }
    }
}
