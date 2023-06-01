using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody2D))]
public class TimeRewind2 : MonoBehaviour {


	public float timeRewind;
	public Slider slider;
	//public Text text;
	public int intYellow;
	//public int YellowDrink;
	Rigidbody2D rigidbody;
	public GameObject Replai;
	//public Joystick joystick;
	public MytantManager MM;
	public bool MMEnabled;

bool isRewind;
List<Vector3> PositionList;


// Use this for initialization
void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
	PositionList = new List<Vector3> ();
	slider.maxValue = timeRewind / Time.fixedDeltaTime;
		if (PlayerPrefs.GetInt("SaveMutatorInt") == 1) MMEnabled = false;
		else MMEnabled = true;

	}
void FixedUpdate()
{
	if (isRewind) 
	{
		if (PositionList.Count > 0) {
			int lastPosition = PositionList.Count - 1;
			transform.position = PositionList [lastPosition];
			PositionList.RemoveAt (lastPosition);
			slider.value = PositionList.Count;
				rigidbody.AddRelativeForce(Vector2.down * 0);
				rigidbody.AddRelativeForce(Vector2.up * 0);
				rigidbody.simulated = false;
				rigidbody.velocity = new Vector3(0, 0);

		} else 
		{
				rigidbody.simulated = true;
				intYellow = 0;
				PlayerPrefs.SetInt ("SaveintYellow", intYellow);
				PlayerPrefs.Save ();

		}
	} 
	else 
	{
		if (PositionList.Count >= timeRewind/Time.fixedDeltaTime) 
		{
			PositionList.RemoveAt (0);
		}
		PositionList.Add (transform.position);
		slider.value = PositionList.Count;

	}
		//
		//if ((joystick.Vertical < -0.5) && !isRewind)
		//{
		//	intYellow = 1;
		//	PlayerPrefs.SetInt("SaveintYellow", intYellow);
			//YellowDrink -= 1;
			//PlayerPrefs.SetInt("SaveYellowDrink", YellowDrink);
			//PlayerPrefs.Save();
		//}
		//
	}

// Update is called once per frame
void Update () {
		//text.text = "" + PositionList.Count;


		intYellow = PlayerPrefs.GetInt ("SaveintYellow");
		//YellowDrink = PlayerPrefs.GetInt ("SaveYellowDrink");

		if (intYellow == 1) 
	{
		isRewind = true;
			if (MMEnabled) MM.enabled = false;
	}
		if (intYellow == 0) 
	{
		isRewind = false;
			if (MMEnabled) MM.enabled = true;
		}




}
	public void OnClickYellow()
	{
		if (PositionList.Count < 90) Application.LoadLevel(1);
		else
		{
			Replai.SetActive(false);
			Time.timeScale = PlayerPrefs.GetFloat("SaveTimeB");
			//if (YellowDrink > 0)
			//{
			intYellow = 1;
			PlayerPrefs.SetInt("SaveintYellow", intYellow);
			//YellowDrink -= 1;
			//PlayerPrefs.SetInt ("SaveYellowDrink", YellowDrink);
			//PlayerPrefs.Save ();
			//}
		}

	}

}
