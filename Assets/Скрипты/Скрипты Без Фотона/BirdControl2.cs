using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdControl2 : MonoBehaviour {

	public float speed = 10;
	public float tiltSmooth = 5;
	public Vector3 startPos;
	public GameObject LevelChanger;
	public GameObject FlyParticle;
	public GameObject FlyParticle2;
	public Transform Bird;
	//public SpriteRenderer SR;
	public int intBlue;
	int check;

	//
	[SerializeField] private Camera mainCamera;
	public Vector3 Vic;
	public Vector3 Vic2;
	//
	public bool Inver = false, Inver2 = false;
	//float timefly;

	Rigidbody2D rigidbody;
	Quaternion downRotation;
	Quaternion forwardRotation;

	void Start() {
		rigidbody = GetComponent<Rigidbody2D>();

		check = 0;
		PlayerPrefs.SetInt("SaveCheck", check);
		PlayerPrefs.Save();
		Vic.x = -1;
	}
	public void Fly()
    {
		if (Time.timeScale == 0) return;

		transform.rotation = forwardRotation;
		float B = PlayerPrefs.GetFloat("SaveTimeB");// * 0.75f;
		if (B <= 1.75f) 
		{
			if (B <= 1.5f)
			{
				if (B <= 1.35f)
				{
					rigidbody.AddForce(Vector2.up * speed * 1.75f * 1.35f, ForceMode2D.Force);
				}
				else
				{
					rigidbody.AddForce(Vector2.up * speed * 1.75f * B, ForceMode2D.Force);
				}
			}
			else
			{
				rigidbody.AddForce(Vector2.up * speed * 1.75f * B, ForceMode2D.Force);
			}
		}
		else
		{
			B = 1.75f;
			rigidbody.AddForce(Vector2.up * speed * 1.75f * B, ForceMode2D.Force);
		}

		GameObject g = Instantiate(FlyParticle, Bird.position, Quaternion.identity);
		Destroy(g, 5);

		GameObject f = Instantiate(FlyParticle2, Bird.position, Quaternion.identity);
		Destroy(f, 5);
	}
	void Update() 
	{
		if (Inver2)
		{
			BirdInvers();
		}
        else
        {
			Bird_NotInvers();
		}

		transform.rotation = Quaternion.Lerp (transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
		//timefly += Time.deltaTime;

		Collision_Brevno();

		FlyControl();

	}
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

	public void BirdInvers()
    {
		downRotation = Quaternion.Euler(0, 0, 210);
		forwardRotation = Quaternion.Euler(0, 0, 150);
		//SR.flipX = true;
		Vic2.x = -0.29f;
		Vic2.z = 0.29f;
		Vic2.y = 0.29f;
		Bird.localScale = Vic2;
	}
	public void Bird_NotInvers()
	{
		downRotation = Quaternion.Euler(0, 0, -50);
		forwardRotation = Quaternion.Euler(0, 0, 30);
		//SR.flipX = true;
		Vic2.x = 0.29f;
		Vic2.z = 0.29f;
		Vic2.y = 0.29f;
		Bird.localScale = Vic2;
	}

	public void Collision_Brevno()
    {
		intBlue = PlayerPrefs.GetInt("SaveintBlue");

		if (intBlue == 1)
		{
			if (speed < 0) speed = -300f;
			else speed = 300f;
		}
		if (intBlue == 0)
		{
			if (speed < 0) speed = -400f;
			else speed = 400f;
		}
	}

	public void FlyControl()
    {
		if (Input.GetMouseButtonDown(0)) Fly();

		// НУЖНО СРОЧНО УБРАТЬ ИЗ ВСЕХ СКРИПТОВ УПОМИНАНИЕ ПО ПОВОДУ ЭТОГО ЧТО НИЖЕ ЗАКОММЕНТИРОВАННО

		//if (Inver)
		//{
		//	if ((Input.GetMouseButtonDown(0)) && (mainCamera.ScreenToWorldPoint(Input.mousePosition).x < Vic.x)) Fly();
		//}
		//else
		//{
		//	if ((Input.GetMouseButtonDown(0)) && (mainCamera.ScreenToWorldPoint(Input.mousePosition).x > Vic.x)) Fly();
		//}

		if (Input.GetKeyDown(KeyCode.Space)) Fly();
	}
}



