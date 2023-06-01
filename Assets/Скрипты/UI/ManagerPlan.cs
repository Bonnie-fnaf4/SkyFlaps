using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPlan : MonoBehaviour {
	public GameObject Plan1;
	public GameObject Plan2;
	public GameObject Plan3;
	public GameObject Plan4;
	public GameObject Plan5;
	public int Plan;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ( Plan == 0)
		{
			Plan = Random.Range (1, 5);
		}
	}
}
