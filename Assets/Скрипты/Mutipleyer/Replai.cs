using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Replai : MonoBehaviour {

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
		Application.LoadLevel (1);
	}
	public void OnClickPause()
    {
		if (Time.timeScale == 0);
		else
		{
			Pause.SetActive(true);
		}
	}
	public void OnClickNext()
	{
		Pause.SetActive(false);
	}
}
