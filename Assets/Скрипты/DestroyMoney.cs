using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMoney : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)

    {

        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject, 4);
        }

    }
}
