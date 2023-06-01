using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slohsnost : MonoBehaviour
{
    public int intSloshnost;

    public void SL()
    {
        PlayerPrefs.SetInt("SaveintSloshnost", intSloshnost);
    }
}
