using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdNotInversion : MonoBehaviour
{
    public BirdControl2 Bird;
    public Rigidbody2D Rb;
    // Start is called before the first frame update
    void Start()
    {
        Bird = GetComponent<BirdControl2>();
        Rb = GetComponent<Rigidbody2D>();
        Bird.speed = -1 * Bird.speed;
        Rb.gravityScale = -1 * Rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
