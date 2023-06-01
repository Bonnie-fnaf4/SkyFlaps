using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
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
        if (position.y < -7.5 && position.y > -7.55)
        {
            direction.y = 0;
        }
		if (position.y < -4 && position.y > -4.05)
		{
			direction.y = 0;
		}
        if (position.y > 9 && position.y < 9.05)
        {
            direction.y = 0;
        }
		if (position.y > 16.5 && position.y < 16.55)
		{
			direction.y = 0;
		}
        if (position.y > 23 && position.y < 23.05)
        {
            direction.y = 0;
        }
		if (position.y > 30.5 && position.y < 30.55)
		{
			direction.y = 0;
		}
        if (position.y > 38 && position.y < 38.05)
        {
            direction.y = 0;
        }
		if (position.y > 45.5 && position.y < 45.55)
		{
			direction.y = 0;
		}
        if (position.y > 53 && position.y < 53.05)
        {
            direction.y = 0;
        }
		if (position.y > 60.5 && position.y < 60.55)
		{
			direction.y = 0;
		}
        if (position.y > 68 && position.y < 68.05)
        {
            direction.y = 0;
        }
		if (position.y > 75.5 && position.y < 75.55)
		{
			direction.y = 0;
		}
        if (position.y > 83 && position.y < 83.05)
        {
            direction.y = 0;
        }
		if (position.y > 90.5 && position.y < 90.55)
		{
			direction.y = 0;
		}
        if (position.y > 98 && position.y < 98.05)
        {
            direction.y = 0;
        }
		if (position.y > 107.5 && position.y < 107.55)
		{
			direction.y = 0;
		}
        if (position.y > 113 && position.y < 113.05)
        {
            direction.y = 0;
        }
        if (position.y > 120)
        {
            direction.y = 0;
        }
        if (position.y < -8)
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
        if (col.gameObject.tag == "tube3")
        {
            direction.y = -5;



        }
    }
}