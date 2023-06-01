using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Skins : MonoBehaviour
{

	//public Color ColorBird;
	//public Slider RS, GS, BS;
	//public Image Bird, Hvost, Crilo;

	//public Image[] Odesda, Dopodeshda, NaDopodeshda, Shalpa;
	public int SS, SDP, SVO;
	public Button[] SelectButton;
	public GameObject[] GSS;
	public GameObject[] GSVO;
	public GameObject[] GSDP;
	// Use this for initialization
	void Start() 
	{
		GSS[PlayerPrefs.GetInt("SaveSS")].SetActive(true);
		GSVO[PlayerPrefs.GetInt("SaveSVO")].SetActive(true);
		GSDP[PlayerPrefs.GetInt("SaveSDP")].SetActive(true);
	}

	void Update()
	{
		//ColorBird = new Color(RS.value, GS.value, BS.value);
		//Bird.color = ColorBird;
		//Hvost.color = ColorBird;
		//Crilo.color = ColorBird;
	}

	public void ClikcSS()
    {
		for (int i = 0; i < GSS.Length; i++)
		{
			if (GSS[i].activeSelf == true)
			{
				SS = i;
				PlayerPrefs.SetInt("SaveSS", SS);
			}
		}
    }
	public void ClikcSVO()
	{
		for (int i = 0; i < GSVO.Length; i++)
		{
			if (GSVO[i].activeSelf == true)
			{
				SVO = i;
				PlayerPrefs.SetInt("SaveSVO", SVO);
			}
		}
	}
	public void ClikcSDP()
	{
		for (int i = 0; i < GSDP.Length; i++)
		{
			if (GSDP[i].activeSelf == true)
			{
				SDP = i;
				PlayerPrefs.SetInt("SaveSDP", SDP);
			}
		}
	}
}