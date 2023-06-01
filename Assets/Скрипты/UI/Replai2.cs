using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Replai2 : MonoBehaviour {

	public GameObject Pause;
	public GameObject Replay;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			OnClickPause();
		}
	}
	public void OnClicReplai ()
	{
		Time.timeScale = 1;
		Application.LoadLevel (1);
	}
	public void OnClickPause()
    {
		if (Time.timeScale == 0);
		else
		{
			Time.timeScale = 0;
			Pause.SetActive(true);
		}
	}
	public void OnClickNext()
	{
		Time.timeScale = PlayerPrefs.GetFloat("SaveTimeB");
		Pause.SetActive(false);
	}
}
