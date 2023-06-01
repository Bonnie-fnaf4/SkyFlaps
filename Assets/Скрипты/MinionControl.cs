using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MinionControl  : MonoBehaviour {
		public float speed = 10;
		public float tiltSmooth = 5;
		public Vector3 startPos;
	public int intBlue;
	public int intspeed;

		Rigidbody2D rigidbody;


		void Start() {
			rigidbody = GetComponent<Rigidbody2D> ();


		}

		void Update() 
		{
			if (Input.GetMouseButtonDown (0)) 
			{
				
				rigidbody.AddForce (Vector2.up * speed, ForceMode2D.Force);
			}
		intBlue = PlayerPrefs.GetInt ("SaveintBlue");
		intspeed = PlayerPrefs.GetInt ("SaveintSpeed");

		if (intBlue == 1) {
			speed = 240f;
		}

		if (intBlue == 0) {
			speed = 300f;
		}
		if (intspeed == 1) {
			speed = 60f;
		}
		if (intspeed == 2) {
			speed = 120f;
		}
		if (intspeed == 3) {
			speed = 180f;
		}
		if (intspeed == 4) {
			speed = 240f;
		}
		if (intspeed == 5) {
			speed = 300f;
		}
		if (intspeed == 6) {
			speed = 360f;
		}
		if (intspeed == 7) {
			speed = 420f;
		}
		if (intspeed == 8) {
			speed = 480f;
		}
		if (intspeed == 9) {
			speed = 940f;
		}
		}
	}
