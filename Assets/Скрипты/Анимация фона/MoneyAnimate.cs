using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyAnimate : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)

    {

        if (other.gameObject.tag == "Player")
        {
            anim.SetTrigger("MoneyLeave");
            //Destroy(gameObject);
        }

    }
}
