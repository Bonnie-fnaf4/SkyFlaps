using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUpAndBottom : MonoBehaviour
{
	public GameObject LevelChanger;
	int intBlue;
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Amogus")
		{
			LevelChanger.SetActive(true);
			Time.timeScale = 0;
			intBlue = 0;
			PlayerPrefs.SetInt("SaveintBlue", intBlue);
			intBlue = PlayerPrefs.GetInt("SaveintBlue");
			PlayerPrefs.Save();
		}
	}
}
