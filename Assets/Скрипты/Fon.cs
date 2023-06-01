using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fon : MonoBehaviour {
    public Transform Fon2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = transform.position;
        if (position.y < 1)
        {
            position.y = 0;
        }
	}
}
