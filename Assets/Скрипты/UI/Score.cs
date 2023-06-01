using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public int Score_Player;
	public int Score_PlayerHight;
	Rigidbody2D body;
	public Text txt;
	public Text txt2;
	public bool onDeath;

	// Use this for initialization
	void Start () {
		
			body = GetComponent<Rigidbody2D>();	
		txt.text = "Рекорд " ;
		txt2.text = "Лучший рекорд ";
	}

	// Update is called once per frame

	void OnCollisionEnter2D(Collision2D col)
	{
		txt.text = "Рекорд " + Score_Player;
		if (col.gameObject.tag == "tube2") 
		{
			Score_Player += 1;

		

		}
	

	}
	void Update() 
	{
		if (Score_Player > Score_PlayerHight) 
		{
			PlayerPrefs.SetInt ("Savescore", Score_Player);
			PlayerPrefs.Save ();
			Debug.Log ("save");
		}
		Score_PlayerHight = PlayerPrefs.GetInt ("Savescore");
		txt.text = "Рекорд " + Score_Player;
		txt2.text = "Лучший рекорд " + Score_PlayerHight;
		if (Input.GetKeyDown (KeyCode.D)) 
		{
			PlayerPrefs.DeleteAll ();
		}
	}
}
