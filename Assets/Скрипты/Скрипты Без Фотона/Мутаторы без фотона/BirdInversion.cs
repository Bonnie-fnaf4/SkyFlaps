using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdInversion : MonoBehaviour
{
    public BirdControl2 Bird;
    public Rigidbody2D Rb;

    public bool On = false;
    public bool Check = true;
    // Start is called before the first frame update
    void Start()
    {
        Bird = GetComponent<BirdControl2>();
        Rb = GetComponent<Rigidbody2D>();
        //Bird.speed = -1 * Bird.speed;
        //Rb.gravityScale = -1 * Rb.gravityScale;
        //On = true;
        //Check = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(On && !Check)
        {
            Bird.speed = -1 * Bird.speed;
            Rb.gravityScale = -1 * Rb.gravityScale;
            Check = true;
        }

        if (!On && !Check)
        {
            Bird.speed = -1 * Bird.speed;
            Rb.gravityScale = -1 * Rb.gravityScale;
            Check = true;
        }
    }
}
