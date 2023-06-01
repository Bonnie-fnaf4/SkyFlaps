using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnClickStartGame()
	{
		Application.LoadLevel (1);
	}
	public void OnClickHomeBack()
	{
		Application.LoadLevel (0);
		Time.timeScale = 1;
	}

}
