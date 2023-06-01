using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsinGame : MonoBehaviour
{
	public GameObject[] GSS;
	public SpriteRenderer GSSС;
	public GameObject[] GSVO;
	public SpriteRenderer GSVOС;
	public GameObject[] GSDP;
	public SpriteRenderer GSDPС;
	public SkinsinGame SIG;

	public SpriteRenderer[] GSBC;

	public int a;
	public float r,g,b;
	public bool Bbool = false;
	// Use this for initialization
	void Start()
	{
		Bbool = false;
		//Для шапок
		a = PlayerPrefs.GetInt("SaveSS");
		GSS[a].SetActive(true);
		if (!(a == 0))
		{
			GSSС = GSS[a].GetComponent<SpriteRenderer>();
			r = PlayerPrefs.GetFloat("SaveSColorR");
			g = PlayerPrefs.GetFloat("SaveSColorG");
			b = PlayerPrefs.GetFloat("SaveSColorB");
			GSSС.color = new Color(r, g, b, 1);
		}

		//Для Верхней одежды
		if (PlayerPrefs.GetInt("SaveBBoolColor") == 1) Bbool = true;
		a = PlayerPrefs.GetInt("SaveSVO");
		GSVO[a].SetActive(true);
		if (!(a == 0))
		{
			GSVOС = GSVO[a].GetComponent<SpriteRenderer>();
			r = PlayerPrefs.GetFloat("SaveVOColorR");
			g = PlayerPrefs.GetFloat("SaveVOColorG");
			b = PlayerPrefs.GetFloat("SaveVOColorB");
			GSVOС.color = new Color(r, g, b, 1);
			if (Bbool) GSBC[1].color = new Color(r, g, b, 1);
		}

		//Для украшений
		a = PlayerPrefs.GetInt("SaveSDP");
		GSDP[a].SetActive(true);
		GSDPС = GSDP[a].GetComponent<SpriteRenderer>();
		if (!(a == 0))
		{
			r = PlayerPrefs.GetFloat("SaveDPColorR");
			g = PlayerPrefs.GetFloat("SaveDPColorG");
			b = PlayerPrefs.GetFloat("SaveDPColorB");
			GSDPС.color = new Color(r, g, b, 1);
		}

		//Для Птички
		r = PlayerPrefs.GetFloat("SaveBColorR");
		g = PlayerPrefs.GetFloat("SaveBColorG");
		b = PlayerPrefs.GetFloat("SaveBColorB");
		GSBC[0].color = new Color(r, g, b, 1);
		if (!Bbool) GSBC[1].color = new Color(r, g, b, 1);
		//GSVO[PlayerPrefs.GetInt("SaveSVO")].SetActive(true);
		//GSDP[PlayerPrefs.GetInt("SaveSDP")].SetActive(true);
		SIG.enabled = false;
	}
}
