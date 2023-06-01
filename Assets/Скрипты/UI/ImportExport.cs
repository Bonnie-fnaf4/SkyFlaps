using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImportExport : MonoBehaviour {

	public GameObject Timer3;
	public GameObject BlueTimerActive;
	public int Money;
	public int BlueDrink;
	public int GreenDrink;
	public int YellowDrink;
	public float Timer;
	public int intTimer;
	public int intBlue;
	public float BlueTimer;
	public int intYellow;
	public Text Blue;
	public Text Green;
	public Text Yellow;
	public Text Timer1;
	public Text Timer2;
	public Joystick joystick;


	// Use this for initialization
	void Start () {
		Blue.text = "" + BlueDrink;
		Green.text = "" + GreenDrink;
		Yellow.text = "" + YellowDrink;
		Timer1.text = "" + Timer;
		Timer2.text = "" + BlueTimer;


	}


	
	// Update is called once per frame
	void Update () {
		Blue.text = "" + BlueDrink;
		Green.text = "" + GreenDrink;
		Yellow.text = "" + YellowDrink;
		Money = PlayerPrefs.GetInt ("SaveMoney");
		GreenDrink = PlayerPrefs.GetInt ("SaveGreenDrink");
		BlueDrink = PlayerPrefs.GetInt ("SaveBlueDrink");
		YellowDrink = PlayerPrefs.GetInt ("SaveYellowDrink");
		intBlue = PlayerPrefs.GetInt ("SaveintBlue");
		intYellow = PlayerPrefs.GetInt ("SaveintYellow");
		Timer1.text = "" + Timer;
		Timer2.text = "" + BlueTimer;

		if (intTimer == 1) 
		{
			Timer += Time.deltaTime;
		}
		if (Timer >= 5) 
		{
			Timer = 0;
			Timer3.SetActive (true);
			Time.timeScale = 1;
			intTimer -= 1;

		}
		if (intBlue == 1) 
		{
			BlueTimer += Time.deltaTime;
		}
		if (BlueTimer >= 10) 
		{
			BlueTimer = 0;
			intBlue -= 1;
			BlueTimerActive.SetActive (true);
			PlayerPrefs.SetInt ("SaveintBlue", intBlue);
			intBlue = PlayerPrefs.GetInt ("SaveintBlue");
			PlayerPrefs.Save ();
		}

		//

		if((joystick.Horizontal > 0.5) && (intBlue == 0))
        {
			if (BlueDrink > 0)
			{
				BlueDrink -= 1;
				intBlue = 1;
				PlayerPrefs.SetInt("SaveintBlue", intBlue);
				intBlue = PlayerPrefs.GetInt("SaveintBlue");
				PlayerPrefs.SetInt("SaveBlueDrink", BlueDrink);
				PlayerPrefs.Save();
				BlueDrink = PlayerPrefs.GetInt("SaveBlueDrink");
				BlueTimerActive.SetActive(false);
			}
		}
		if ((joystick.Horizontal < -0.5) && (Time.timeScale == 1f))
		{
			if (GreenDrink > 0)
			{
				Time.timeScale = 0.5f;
				intTimer += 1;
				Timer3.SetActive(false);
				GreenDrink -= 1;
				PlayerPrefs.SetInt("SaveGreenDrink", GreenDrink);
				PlayerPrefs.Save();
				GreenDrink = PlayerPrefs.GetInt("SaveGreenDrink");
			}
		}

		//
	}
	public void OnClickBlue ()
	{
		if (Money >= 100) {
			Money -= 100;
			BlueDrink += 1;
			PlayerPrefs.SetInt ("SaveMoney", Money);
			PlayerPrefs.Save ();
			Money = PlayerPrefs.GetInt ("SaveMoney");
			PlayerPrefs.SetInt ("SaveBlueDrink", BlueDrink);
			PlayerPrefs.Save ();
			BlueDrink = PlayerPrefs.GetInt ("SaveBlueDrink");
		}
	}
	public void OnClickGreen ()
	{
		if (Money >= 100) {
			Money -= 100;
			GreenDrink += 1;
			PlayerPrefs.SetInt ("SaveMoney", Money);
			PlayerPrefs.Save ();
			Money = PlayerPrefs.GetInt ("SaveMoney");
			PlayerPrefs.SetInt ("SaveGreenDrink", GreenDrink);
			PlayerPrefs.Save ();
			GreenDrink = PlayerPrefs.GetInt ("SaveGreenDrink");
		}
	}
	public void OnClickYellow ()
	{
		if (Money >= 100) {
			Money -= 100;
			YellowDrink += 1;
			PlayerPrefs.SetInt ("SaveMoney", Money);
			PlayerPrefs.Save ();
			Money = PlayerPrefs.GetInt ("SaveMoney");
			PlayerPrefs.SetInt ("SaveYellowDrink", YellowDrink);
			PlayerPrefs.Save ();
			YellowDrink = PlayerPrefs.GetInt ("SaveYellowDrink");
		}
	}
	public void OnClickMoneyPlus ()
	{
		Money += 1000;

		PlayerPrefs.SetInt ("SaveMoney", Money);
		PlayerPrefs.Save ();
		Money = PlayerPrefs.GetInt ("SaveMoney");
	}
	public void OnClickGreenActive ()
	{
		if (GreenDrink > 0) 
		{
			Time.timeScale = 0.5f;
			intTimer += 1;
			Timer3.SetActive (false);
			GreenDrink -= 1;
			PlayerPrefs.SetInt ("SaveGreenDrink", GreenDrink);
			PlayerPrefs.Save ();
			GreenDrink = PlayerPrefs.GetInt ("SaveGreenDrink");
		}
	}
	public void OnClickBlueActive ()
	{
		if (BlueDrink > 0) 
		{
			BlueDrink -= 1;
			intBlue = 1;
			PlayerPrefs.SetInt ("SaveintBlue", intBlue);
			intBlue = PlayerPrefs.GetInt ("SaveintBlue");
			PlayerPrefs.SetInt ("SaveBlueDrink", BlueDrink);
			PlayerPrefs.Save ();
			BlueDrink = PlayerPrefs.GetInt ("SaveBlueDrink");
			BlueTimerActive.SetActive (false);
		}
	}
	public void OnClickYellowActive ()
	{
		intYellow += 1;
		intYellow = PlayerPrefs.GetInt ("SaveintYellow");
		PlayerPrefs.SetInt ("SaveintYellow", intYellow);
		YellowDrink = PlayerPrefs.GetInt ("SaveYellowDrink");
		PlayerPrefs.SetInt ("SaveYellowDrink", YellowDrink);
		PlayerPrefs.Save ();
	}
}
