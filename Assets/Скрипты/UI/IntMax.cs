using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntMax : MonoBehaviour {
	public int OdehdaLoad;
	public int OdehdaLoad2;
	public int Skin;
	public int Money;
	public int King;
	public int intspeed;
	public int BlueDrink;
	public int GreenDrink;
	public int YellowDrink;
	public int Armorint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		OdehdaLoad = PlayerPrefs.GetInt ("SaveOdehdaLoad");
		OdehdaLoad2 = PlayerPrefs.GetInt ("SaveOdehdaLoad2");
		Skin = PlayerPrefs.GetInt("SaveSkin");
		Money = PlayerPrefs.GetInt ("SaveMoney");
		King = PlayerPrefs.GetInt ("SaveKIng");
		intspeed = PlayerPrefs.GetInt ("SaveintSpeed");
		GreenDrink = PlayerPrefs.GetInt ("SaveGreenDrink");
		BlueDrink = PlayerPrefs.GetInt ("SaveBlueDrink");
		YellowDrink = PlayerPrefs.GetInt ("SaveYellowDrink");
		Armorint = PlayerPrefs.GetInt ("SaveArmorint");
	}
	public void OnClickMin()
	{
		Armorint = 0;
		OdehdaLoad = 0;
		OdehdaLoad2 = 0;
		Skin = 0;
		Money = 0;
		King = 0;
		intspeed = 300;
		BlueDrink = 0;
		GreenDrink = 0;
		YellowDrink = 0;
		PlayerPrefs.SetInt ("SaveMoney", Money);
		PlayerPrefs.SetInt ("SaveOdehdaLoad", OdehdaLoad);
		PlayerPrefs.SetInt ("SaveSkin", Skin);
		PlayerPrefs.SetInt ("SaveOdehdaLoad2", OdehdaLoad2);
		PlayerPrefs.SetInt ("SaveKing", King);
		PlayerPrefs.SetInt ("SaveintSpeed", intspeed);
		PlayerPrefs.SetInt ("SaveBlueDrink", BlueDrink);
		PlayerPrefs.SetInt ("SaveGreenDrink", GreenDrink);
		PlayerPrefs.SetInt ("SaveYellowDrink", YellowDrink);
		PlayerPrefs.SetInt ("SaveArmorint", Armorint);

		PlayerPrefs.Save ();
	}
	public void OnClickMax()
	{
		

		Money = 50000;
		intspeed = 300;
		BlueDrink = 100;
		GreenDrink = 100;
		YellowDrink = 100;
		PlayerPrefs.SetInt ("SaveMoney", Money);
		PlayerPrefs.SetInt ("SaveintSpeed", intspeed);
		PlayerPrefs.SetInt ("SaveBlueDrink", BlueDrink);
		PlayerPrefs.SetInt ("SaveGreenDrink", GreenDrink);
		PlayerPrefs.SetInt ("SaveYellowDrink", YellowDrink);

		PlayerPrefs.Save ();
	}

}
