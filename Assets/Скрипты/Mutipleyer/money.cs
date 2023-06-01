using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class money : MonoBehaviour {

	public int Money;
	public int MoneySave;
	public int Money3;
	public int Money4;
	public int Money5 = 0;
	public int check;
	Rigidbody2D body;
	public Text txt;
	public Text txt2;
	public Text txt3;

	public int intBlue;

	bool  ArmorInt = false;
	bool  ArmorInt2 = false;
	public Text TimerToArmor;
	private CircleCollider2D col2d;
	private double Timer1 = 0;

	public bool onDeath;
	public GameObject LevelChanger;

	public Transform Bird;
	public GameObject MoneyTextMechPro;

	public TimeGameMultiplayer TGM;
	// Use this for initialization
	void Start () {
		Money4 = 0;
		PlayerPrefs.SetInt("SaveRecords", Money4);
		if (25 == PlayerPrefs.GetInt("SaveOdehdaLoad2")) 
		{
			ArmorInt2 = true;
		}
		Money5 = 0;
		col2d = GetComponent<CircleCollider2D>();
		body = GetComponent<Rigidbody2D>();	
		txt.text = "Золото " ;
		txt3.text = "Золото 1 Игрока";
		txt2.text = "Золото 2 Игрока";
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
			if (PlayerPrefs.GetInt("SaveWaitPlayer") == 0)
			{
				Money5 = Money - PlayerPrefs.GetInt("SaveMoney") + Money5;
				PlayerPrefs.SetInt("SaveRecords", Money5);
			}
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
			if (PlayerPrefs.GetInt("SaveWaitPlayer") == 0)
			{
				Money5 = Money - PlayerPrefs.GetInt("SaveMoney") + Money5;
				PlayerPrefs.SetInt("SaveRecords", Money5);
			}
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
			if (PlayerPrefs.GetInt("SaveWaitPlayer") == 0)
			{
				Money5 = Money - PlayerPrefs.GetInt("SaveMoney") + Money5;
				PlayerPrefs.SetInt("SaveRecords", Money5);
			}
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
			Money5 = Money - PlayerPrefs.GetInt("SaveMoney") + Money5;
			PlayerPrefs.SetInt ("SaveMoney", Money);
			PlayerPrefs.SetInt("SaveRecords", Money5);
			PlayerPrefs.Save ();

		}

		if (col.gameObject.tag == "Gold2")
		{
			Money += Random.Range(100, 300);
			Money5 = Money - PlayerPrefs.GetInt("SaveMoney") + Money5;
			PlayerPrefs.SetInt ("SaveMoney", Money);
			PlayerPrefs.SetInt("SaveRecords", Money5);
			PlayerPrefs.Save ();
		}
		if (col.gameObject.tag == "Gold3")
		{
			Money += Random.Range(1, 10);
			Money5 = Money - PlayerPrefs.GetInt("SaveMoney") + Money5;
			PlayerPrefs.SetInt ("SaveMoney", Money);
			PlayerPrefs.SetInt("SaveRecords", Money5);
			PlayerPrefs.Save ();
		}
		if (col.gameObject.tag == "Plan")
		{
			check = 0;
			PlayerPrefs.SetInt("SaveCheck", check);
			PlayerPrefs.Save();
		}
	}
	public void Test()
    {
		Money += Random.Range(10, 50);
		Money5 = Money - PlayerPrefs.GetInt("SaveMoney") + Money5;
		PlayerPrefs.SetInt("SaveMoney", Money);
		PlayerPrefs.SetInt("SaveRecords", Money5);
		PlayerPrefs.Save();
	}
	void Update() 
	{

		MoneySave = PlayerPrefs.GetInt ("SaveMoney");
		Money4 = PlayerPrefs.GetInt("SaveRecords");
		txt.text = "Золото " + Money;
		if (TGM.end) Money5 = 0;
		txt3.text = "Рекорд Ваш " + Money5;
		txt2.text = "Золото 2 Игрока " + Money4;
		Money = PlayerPrefs.GetInt ("SaveMoney");
		if (Input.GetKeyDown (KeyCode.F)) 
		{
			PlayerPrefs.DeleteAll ();
		}
    }
}