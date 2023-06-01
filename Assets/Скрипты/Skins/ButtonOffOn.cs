using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOffOn : MonoBehaviour
{
    public GameObject All;
    // Update is called once per frame
    public void On()
    {
        All.SetActive(true);
    }
    public void Off()
    {
        All.SetActive(false);
    }
}
