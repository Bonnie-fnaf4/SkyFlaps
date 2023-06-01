using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Mainmenu1 : MonoBehaviour {
	public GameObject BirdRed;
	public GameObject BirdBlue;
	public GameObject BirdBrown;
	public GameObject BirdGreen;
	public GameObject BirdPinc;
	public GameObject BirdYellow;
	public GameObject BirdWhite;
	public GameObject BirdViolet;

	public GameObject MapMountinBlue;
	public GameObject MapMountinGreen;
	public GameObject MapMountinViolet;
	public GameObject MapMountinYellow;
	public GameObject MapDezertBlue;
	public GameObject MapDezertGreen;
	public GameObject MapDezertViolet;
	public GameObject MapDezertYellow;

	public GameObject MainMenu;
	public GameObject PanelBird;
	public GameObject PanelMaps;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (MainMenu.activeSelf == true) {
			Time.timeScale = 0;
		}
	}
	public void OnClickBirdblue ()
	{
		BirdBlue.SetActive (true);
		PanelMaps.SetActive (true);
	}
	public void OnClickBirdRed ()
	{
		BirdRed.SetActive (true);
		PanelMaps.SetActive (true);
	}
	public void OnClickBirdGreen ()
	{
		BirdGreen.SetActive (true);
		PanelMaps.SetActive (true);
	}
	public void OnClickBirdYellow ()
	{
		BirdYellow.SetActive (true);
		PanelMaps.SetActive (true);
	}
	public void OnClickBirdWhite ()
	{
		BirdWhite.SetActive (true);
		PanelMaps.SetActive (true);
	}
	public void OnClickBirdPinc ()
	{
		BirdPinc.SetActive (true);
		PanelMaps.SetActive (true);
	}
	public void OnClickBirdViolet ()
	{
		BirdViolet.SetActive (true);
		PanelMaps.SetActive (true);
	}
	public void OnClickBirdBrown ()
	{
		BirdBrown.SetActive (true);
		PanelMaps.SetActive (true);
	}
	public void OnClickMapMauntinBlue ()
	{
		MapMountinBlue.SetActive (true);
		PanelMaps.SetActive (false);
		MainMenu.SetActive (false);
		PanelBird.SetActive (false);
	}
	public void OnClickMapMauntinYellow ()
	{
		MapMountinYellow.SetActive (true);
		PanelMaps.SetActive (false);
		MainMenu.SetActive (false);
		PanelBird.SetActive (false);
	}
	public void OnClickMapMauntinGreen ()
	{
		MapMountinGreen.SetActive (true);
		PanelMaps.SetActive (false);
		MainMenu.SetActive (false);
		PanelBird.SetActive (false);
	}
	public void OnClickMapMauntinViolet ()
	{
		MapMountinViolet.SetActive (true);
		PanelMaps.SetActive (false);
		MainMenu.SetActive (false);
		PanelBird.SetActive (false);
	}
	public void OnClickMapDezertBlue()
	{
		MapDezertBlue.SetActive (true);
		PanelMaps.SetActive (false);
		MainMenu.SetActive (false);
		PanelBird.SetActive (false);
	}
	public void OnClickMapDezertGreen ()
	{
		MapDezertGreen.SetActive (true);
		PanelMaps.SetActive (false);
		MainMenu.SetActive (false);
		PanelBird.SetActive (false);
	}
	public void OnClickMapDezertViolet ()
	{
		MapDezertViolet.SetActive (true);
		PanelMaps.SetActive (false);
		MainMenu.SetActive (false);
		PanelBird.SetActive (false);
	}
	public void OnClickMapDezertYellow ()
	{
		MapDezertYellow.SetActive (true);
		PanelMaps.SetActive (false);
		MainMenu.SetActive (false);
		PanelBird.SetActive (false);
	}
	public void OnClickPlayGame ()
	{
		PanelBird.SetActive (true);
	}
	
}
