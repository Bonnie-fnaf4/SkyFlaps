using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGAnimate : MonoBehaviour
{
    public string parametrs;
    int Oblako = 0;
    int Vodopad = 0;
    int Mech = 0;
    int Topor = 0;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (parametrs == "Oblako")
        {
            Oblako = PlayerPrefs.GetInt("SaveOblako");
            if (Oblako == 1) anim.SetBool("Oblako", true);
            if (Oblako == 0) anim.SetBool("Oblako", false);
        }
        if (parametrs == "Vodopad")
        {
            Vodopad = PlayerPrefs.GetInt("SaveVodopad");
            if (Vodopad == 1) anim.SetBool("Vodopad", true);
            if (Vodopad == 0) anim.SetBool("Vodopad", false);
        }
        if (parametrs == "Mech")
        {
            Mech = PlayerPrefs.GetInt("SaveMech");
            if (Mech == 1) anim.SetBool("Mech", true);
            if (Mech == 0) anim.SetBool("Mech", false);
        }
        if (parametrs == "Topor")
        {
            Topor = PlayerPrefs.GetInt("SaveTopor");
            if (Topor == 1) anim.SetBool("Topor", true);
            if (Topor == 0) anim.SetBool("Topor", false);
        }
    }
}
