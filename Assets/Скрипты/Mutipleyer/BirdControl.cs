using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Linq;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdControl : MonoBehaviour {

	public float speed = 10;
	public float tiltSmooth = 5;
	public Vector3 startPos;
	public GameObject LevelChanger;
	public int intBlue, PVPBreak = 0;
	int check;
	public TextMeshPro NicknameText;
	//
	public PhotonView photonView;
	public GameObject Camera, SpawnPos, CP;
	public CircleCollider2D CL;
	//
	public GameObject FlyParticle;
	public GameObject FlyParticle2;
	public Transform Bird;
	//
	[SerializeField] private Camera mainCamera;
	public Vector3 Vic;
	public Vector3 Vic2;
	//
	//float timefly;

	public MytantManagerMultiplaer2 MMM;

	Rigidbody2D rigidbody;
	Quaternion downRotation;
	Quaternion forwardRotation;

	public SpriteRenderer SR;
	CircleCollider2D CC2D;

	public bool Inver = false, Inver2 = false;

	public int money;

	private BirdControl Bc;
	private StartGame SG;
	public GameObject Tab;
	void Start() {

		photonView = GetComponent<PhotonView>();
		rigidbody = GetComponent<Rigidbody2D> ();
		Bc = GetComponent<BirdControl>();
		SG = GetComponent<StartGame>();
		CL = GetComponent<CircleCollider2D>();
		SR = GetComponent<SpriteRenderer>();
		CC2D = GetComponent<CircleCollider2D>();
		if (MMM.n2)
		{
			downRotation = Quaternion.Euler(0, 0, 210);
			forwardRotation = Quaternion.Euler(0, 0, 150);
			//SR.flipX = true;
			Vic2.x = -1;
			Vic2.z = 1;
			Vic2.y = 1;
			Bird.localScale = Vic2;
		}
		else
		{
			downRotation = Quaternion.Euler(0, 0, -50);
			forwardRotation = Quaternion.Euler(0, 0, 30);
		}
		check = 0;
		PlayerPrefs.SetInt("SaveCheck", check);
		PlayerPrefs.Save();
		if (!photonView.IsMine)
		{
			Camera.SetActive(false);
			SpawnPos.SetActive(false);
			rigidbody.simulated = false;
			CP.SetActive(false);
		}
		else CL.enabled = true;
		NicknameText.SetText(photonView.Owner.NickName);
		Vic.x = -4;
	}
	public void Fly()
    {
		//if (timefly > 0.15)
		//{
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
		//timefly = 0;
		GameObject g = Instantiate(FlyParticle, Bird.position, Quaternion.identity);
		Destroy(g, 5);
		GameObject f = Instantiate(FlyParticle2, Bird.position, Quaternion.identity);
		Destroy(f, 5);
		//}
		//if (timefly < 0.15)
		//{
		//transform.rotation = forwardRotation;
		//rigidbody.AddForce(Vector2.up * speed * timefly, ForceMode2D.Force);
		//timefly = 0;
		//}
	}
	void Update() 
	{
		if (!photonView.IsMine) return;
		money = PlayerPrefs.GetInt("SaveMoney");
		intBlue = PlayerPrefs.GetInt ("SaveintBlue");
		if (Inver2)
		{
			downRotation = Quaternion.Euler(0, 0, 210);
			forwardRotation = Quaternion.Euler(0, 0, 150);
			//SR.flipX = true;
			Vic2.x = -1;
			Vic2.z = 1;
			Vic2.y = 1;
			Bird.localScale = Vic2;
		}
		else
		{
			downRotation = Quaternion.Euler(0, 0, -50);
			forwardRotation = Quaternion.Euler(0, 0, 30);
			Vic2.x = 1;
			Vic2.z = 1;
			Vic2.y = 1;
			Bird.localScale = Vic2;
		}
		transform.rotation = Quaternion.Lerp (transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
		//timefly += Time.deltaTime;
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

		FlyControl();
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

	public void BreakPVP()
    {
		//PVPBreak = 1;
		//PlayerPrefs.SetInt("SavePVPBreak", PVPBreak);

		PlayerPrefs.SetInt("SaveWaitPlayer", 1);
		Tab.SetActive(true);
		rigidbody.gravityScale = 0;
		forwardRotation = Quaternion.Euler(0, 0, 30);
		SG.enabled = true;
		Bc.enabled = false;
		CC2D.isTrigger = true;
		rigidbody.velocity = new Vector3(0, 0);
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "tube")
		{
			BreakPVP();
		}
	}
}



