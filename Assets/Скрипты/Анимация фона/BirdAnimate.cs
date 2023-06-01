using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimate : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent < Animator >();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Fly");
        }
    }
}
