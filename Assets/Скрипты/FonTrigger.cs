using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FonTrigger : MonoBehaviour
{
	int checkFon;
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "checkFon")
		{
			checkFon = 0;
			PlayerPrefs.SetInt("SavecheckFon", checkFon);
			PlayerPrefs.Save();
		}
	}

}
