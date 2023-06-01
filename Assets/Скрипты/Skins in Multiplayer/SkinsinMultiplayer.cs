using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class SkinsinMultiplayer : MonoBehaviour, IPunObservable
{
	private PhotonView photonView;
	public GameObject[] GSS;
	public SpriteRenderer GSSС;
	public GameObject[] GSVO;
	public SpriteRenderer GSVOС;
	public GameObject[] GSDP;
	public SpriteRenderer GSDPС;
	public SkinsinMultiplayer SIG;

	public SpriteRenderer[] GSBC;

	public int Sa;
	public int VOa;
	public int DPa;

	public float Sr,  Sg,  Sb;
	public float VOr, VOg, VOb;
	public float DPr, DPg, DPb;
	public float Br,  Bg,  Bb;
	public bool Bbool = false;
	// Use this for initialization
	void Start()
	{
		photonView = GetComponent<PhotonView>();
		if (!(photonView.IsMine))
		{
			GSS[Sa].SetActive(true);
			if (!(Sa == 0))
			{
				GSSС = GSS[Sa].GetComponent<SpriteRenderer>();
				GSSС.color = new Color(Sr, Sg, Sb, 1);
			}

			//Для Верхней одежды
			GSVO[VOa].SetActive(true);
			if (!(VOa == 0))
			{
				GSVOС = GSVO[VOa].GetComponent<SpriteRenderer>();
				GSVOС.color = new Color(VOr, VOg, VOb, 1);
				if (Bbool) GSBC[1].color = new Color(VOr, VOg, VOb, 1);
			}

			//Для украшений
			GSDP[DPa].SetActive(true);
			GSDPС = GSDP[DPa].GetComponent<SpriteRenderer>();
			if (!(DPa == 0))
			{
				GSDPС.color = new Color(DPr, DPg, DPb, 1);
			}

			//Для Птички
			GSBC[0].color = new Color(Br, Bg, Bb, 1);
			if (!Bbool) GSBC[1].color = new Color(Br, Bg, Bb, 1);
			//GSVO[PlayerPrefs.GetInt("SaveSVO")].SetActive(true);
			//GSDP[PlayerPrefs.GetInt("SaveSDP")].SetActive(true);
			SIG = GetComponent<SkinsinMultiplayer>();
			SIG.enabled = false;
		}
		else
		{
			Bbool = false;
			//Для шапок
			Sa = PlayerPrefs.GetInt("SaveSS");
			GSS[Sa].SetActive(true);
			if (!(Sa == 0))
			{
				GSSС = GSS[Sa].GetComponent<SpriteRenderer>();
				Sr = PlayerPrefs.GetFloat("SaveSColorR");
				Sg = PlayerPrefs.GetFloat("SaveSColorG");
				Sb = PlayerPrefs.GetFloat("SaveSColorB");
				GSSС.color = new Color(Sr, Sg, Sb, 1);
			}

			//Для Верхней одежды
			if (PlayerPrefs.GetInt("SaveBBoolColor") == 1) Bbool = true;
			VOa = PlayerPrefs.GetInt("SaveSVO");
			GSVO[VOa].SetActive(true);
			if (!(VOa == 0))
			{
				GSVOС = GSVO[VOa].GetComponent<SpriteRenderer>();
				VOr = PlayerPrefs.GetFloat("SaveVOColorR");
				VOg = PlayerPrefs.GetFloat("SaveVOColorG");
				VOb = PlayerPrefs.GetFloat("SaveVOColorB");
				GSVOС.color = new Color(VOr, VOg, VOb, 1);
				if (Bbool) GSBC[1].color = new Color(VOr, VOg, VOb, 1);
			}

			//Для украшений
			DPa = PlayerPrefs.GetInt("SaveSDP");
			GSDP[DPa].SetActive(true);
			GSDPС = GSDP[DPa].GetComponent<SpriteRenderer>();
			if (!(DPa == 0))
			{
				DPr = PlayerPrefs.GetFloat("SaveDPColorR");
				DPg = PlayerPrefs.GetFloat("SaveDPColorG");
				DPb = PlayerPrefs.GetFloat("SaveDPColorB");
				GSDPС.color = new Color(DPr, DPg, DPb, 1);
			}

			//Для Птички
			Br = PlayerPrefs.GetFloat("SaveBColorR");
			Bg = PlayerPrefs.GetFloat("SaveBColorG");
			Bb = PlayerPrefs.GetFloat("SaveBColorB");
			GSBC[0].color = new Color(Br, Bg, Bb, 1);
			if (!Bbool) GSBC[1].color = new Color(Br, Bg, Bb, 1);
			//GSVO[PlayerPrefs.GetInt("SaveSVO")].SetActive(true);
			//GSDP[PlayerPrefs.GetInt("SaveSDP")].SetActive(true);
			//SIG.enabled = false;
		}
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.IsWriting)
		{
			stream.SendNext(Bbool);

			stream.SendNext(Sa);
			stream.SendNext(VOa);
			stream.SendNext(DPa);

			stream.SendNext(Sr);  stream.SendNext(Sg);  stream.SendNext(Sb);

			stream.SendNext(VOr); stream.SendNext(VOg); stream.SendNext(VOb);

			stream.SendNext(DPr); stream.SendNext(DPg); stream.SendNext(DPb);

			stream.SendNext(Br);  stream.SendNext(Bg);  stream.SendNext(Bb);
		}
		else
		{
			Bbool = (bool)stream.ReceiveNext();

			Sa  = (int)stream.ReceiveNext();
			VOa = (int)stream.ReceiveNext();
			DPa = (int)stream.ReceiveNext();

			Sr  = (float)stream.ReceiveNext(); Sg  = (float)stream.ReceiveNext(); Sb  = (float)stream.ReceiveNext();

			VOr = (float)stream.ReceiveNext(); VOg = (float)stream.ReceiveNext(); VOb = (float)stream.ReceiveNext();

			DPr = (float)stream.ReceiveNext(); DPg = (float)stream.ReceiveNext(); DPb = (float)stream.ReceiveNext();

			Br  = (float)stream.ReceiveNext(); Bg  = (float)stream.ReceiveNext(); Bb  = (float)stream.ReceiveNext();
		}
	}
}
