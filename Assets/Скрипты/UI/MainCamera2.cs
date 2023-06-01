using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera2 : MonoBehaviour
{
    public Vector2 direction;
    public Transform Bird;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        transform.Translate(direction * Time.deltaTime);
        if (direction.y > 0 && position.y > 5)
        {
            direction.y = 0;
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "tube2")
        {
            direction.y = 5;



        }
    }
}