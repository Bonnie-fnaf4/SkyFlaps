using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Trigger : MonoBehaviour {
	public int Armor;
	public int OdehdaLoad2;
	public float Timer;
	public int intTimer;
	public GameObject LevelChanger;
	public int Plan;


	// Use this for initialization
	void Start () {
		OdehdaLoad2 = PlayerPrefs.GetInt ("SaveOdehdaLoad2");
		Armor = PlayerPrefs.GetInt ("SaveArmor");
		if (OdehdaLoad2 == 25) {
			Armor = 1;
			PlayerPrefs.SetInt ("SaveArmor", Armor);
			PlayerPrefs.Save ();
		}

	}
	
	// Update is called once per frame
	void Update () {
		Timer = PlayerPrefs.GetFloat ("SaveTimerTimer");
		intTimer = PlayerPrefs.GetInt ("SaveintTimerTimer");
		if (intTimer > 0) 
		{
			Timer += Time.deltaTime;
			PlayerPrefs.SetFloat ("SaveTimerTimer", Timer);
			PlayerPrefs.Save ();
		}
		if (Timer > 3) 
		{
			intTimer = 0;
			Timer = 0;
			Armor = 0;
			PlayerPrefs.SetFloat ("SaveTimerTimer", Timer);
			PlayerPrefs.SetInt ("SaveArmor", Armor);
			PlayerPrefs.Save ();
		}
	}


	void OnTriggerEnter2D (Collider2D other)
	{
			

	}
}
