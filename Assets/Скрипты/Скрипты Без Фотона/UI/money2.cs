using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class money2 : MonoBehaviour {

	public int Money;
	public int MoneySave;
	public int Money3;
	public int Money4;
	public int Money5;
	public int check;
	Rigidbody2D body;
	public Text txt;
	public Text txt2;

	public int intBlue;

	bool  ArmorInt = false;
	bool  ArmorInt2 = false;
	public Text TimerToArmor;
	private CircleCollider2D col2d;
	private double Timer1 = 0;
	public Transform Bird;

	public bool onDeath;
	public GameObject LevelChanger;
	public GameObject MoneyTextMechPro;

	// Use this for initialization
	void Start () {
		//
		Money3 = 0;
		PlayerPrefs.SetInt("SaveMoneyText", Money3);
		GameObject g = Instantiate(MoneyTextMechPro, Bird.position, Quaternion.identity);
		Destroy(g, 3);
		//
		if (25 == PlayerPrefs.GetInt("SaveOdehdaLoad2")) 
		{
			ArmorInt2 = true;
		}
		col2d = GetComponent<CircleCollider2D>();
		body = GetComponent<Rigidbody2D>();	
		txt.text = "Золото " ;
		txt2.text = "Сохранёное золото" ;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		txt.text = "Золото " + Money;
		if (other.gameObject.tag == "Gold")
		{
			Money3 = Random.Range(10, 50);
			Money += (int)(Money3 * PlayerPrefs.GetFloat("SaveTimeB") * PlayerPrefs.GetInt("SaveMMX"));
			PlayerPrefs.SetInt("SaveMoneyText", Money3);
			GameObject g = Instantiate(MoneyTextMechPro, Bird.position, Quaternion.identity);
			Destroy(g, 3);
			PlayerPrefs.SetInt("SaveMoney", Money);
			PlayerPrefs.Save();

		}

		if (other.gameObject.tag == "Gold2")
		{
			Money3 = Random.Range(100, 300);
			Money += (int)(Money3 * PlayerPrefs.GetFloat("SaveTimeB") * PlayerPrefs.GetInt("SaveMMX"));
			PlayerPrefs.SetInt("SaveMoneyText", Money3);
			GameObject g = Instantiate(MoneyTextMechPro, Bird.position, Quaternion.identity);
			Destroy(g, 3);
			PlayerPrefs.SetInt("SaveMoney", Money);
			PlayerPrefs.Save();
		}
		if (other.gameObject.tag == "Gold3")
		{
			Money3 = Random.Range(1, 10);
			Money += (int)(Money3 * PlayerPrefs.GetFloat("SaveTimeB") * PlayerPrefs.GetInt("SaveMMX"));
			PlayerPrefs.SetInt("SaveMoneyText", Money3);
			GameObject g = Instantiate(MoneyTextMechPro, Bird.position, Quaternion.identity);
			Destroy(g, 3);
			PlayerPrefs.SetInt("SaveMoney", Money);
			PlayerPrefs.Save();
		}
	}
	// Update is called once per frame

	void OnCollisionEnter2D(Collision2D col)
	{
		
		if (col.gameObject.tag == "Gold") 
		{
			Money += Random.Range(10, 50);
			PlayerPrefs.SetInt ("SaveMoney", Money);
			PlayerPrefs.Save ();

		}

		if (col.gameObject.tag == "Gold2")
		{
			Money += Random.Range(100, 300);
			PlayerPrefs.SetInt ("SaveMoney", Money);
			PlayerPrefs.Save ();
		}
		if (col.gameObject.tag == "Gold3")
		{
			Money += Random.Range(1, 10);
			PlayerPrefs.SetInt ("SaveMoney", Money);
			PlayerPrefs.Save ();
		}
		if (col.gameObject.tag == "tube")
		{
			if (ArmorInt2 == true)
			{
				ArmorInt = true;
			}
			else
			{
				LevelChanger.SetActive(true);
				Time.timeScale = 0;
				intBlue = 0;
				PlayerPrefs.SetInt("SaveintBlue", intBlue);
				intBlue = PlayerPrefs.GetInt("SaveintBlue");
				PlayerPrefs.Save();
			}
		}
		if (col.gameObject.tag == "Plan")
		{
			check = 0;
			PlayerPrefs.SetInt("SaveCheck", check);
			PlayerPrefs.Save();
		}
	}
	void Update() 
	{
		if (ArmorInt == true)
        {
			Timer1 += Time.deltaTime;
			TimerToArmor.text = "" + Timer1;
			col2d.enabled = false;
			if(Timer1 > 5)
            {
				ArmorInt = false;
				ArmorInt2 = false;
				col2d.enabled = true;
			}
		}
		MoneySave = PlayerPrefs.GetInt ("SaveMoney");
		txt.text = "Золото " + Money;
		Money = PlayerPrefs.GetInt ("SaveMoney");
		txt2.text = "Созранёное золото " + MoneySave;
		if (Input.GetKeyDown (KeyCode.F)) 
		{
			PlayerPrefs.DeleteAll ();
		}
    }
}