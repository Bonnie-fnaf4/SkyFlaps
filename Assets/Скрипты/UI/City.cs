using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class City : MonoBehaviour {
	public int Money;
	public Text txt;
	// Use this for initialization
	void Start () {
		txt.text = "Золото " ;
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = "Золото " + Money;
		Money = PlayerPrefs.GetInt ("SaveMoney");
	}
}