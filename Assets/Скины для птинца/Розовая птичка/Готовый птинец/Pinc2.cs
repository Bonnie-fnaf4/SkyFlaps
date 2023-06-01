using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinc2 : MonoBehaviour {

	public Animation anim; 

	void Update () {

		if(Input.GetKeyDown (KeyCode.E)){
			anim = GetComponent<Animation>();
			anim.Play("pinc2");
		}
	}
}