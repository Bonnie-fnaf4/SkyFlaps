using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu2 : MonoBehaviour {
	public GameObject BirdRed;
	public GameObject BirdBlue;
	public GameObject BirdBrown;
	public GameObject BirdGreen;
	public GameObject BirdPinc;
	public GameObject BirdYellow;
	public GameObject BirdWhite;
	public GameObject BirdViolet;

	public GameObject BirdRedArmor;
	public GameObject BirdBlueArmor;
	public GameObject BirdBrownArmor;
	public GameObject BirdGreenArmor;
	public GameObject BirdPincArmor;
	public GameObject BirdYellowArmor;
	public GameObject BirdWhiteArmor;
	public GameObject BirdVioletArmor;

	public GameObject fly_White;
	public GameObject fly_Green;
	public GameObject fly_Blue;
	public GameObject fly_Pinc;
	public GameObject fly_Red;
	public GameObject fly_Violet;
	public GameObject fly_Brown;
	public GameObject fly_Yellow;

	public GameObject fly_YellowArmor;
	public GameObject fly_BlueArmor;
	public GameObject fly_RedArmor;
	public GameObject fly_GreenArmor;
	public GameObject fly_BrownArmor;
	public GameObject fly_VioletArmor;
	public GameObject fly_PincArmor;
	public GameObject fly_WhiteArmor;

	public GameObject MapMountinBlue;
	public GameObject MapMountinGreen;
	public GameObject MapMountinViolet;
	public GameObject MapMountinYellow;
	public GameObject MapDezertBlue;
	public GameObject MapDezertGreen;
	public GameObject MapDezertViolet;
	public GameObject MapDezertYellow;

	public GameObject PanelBlue;
	public GameObject PanelRed;
	public GameObject PanelGreen;
	public GameObject PanelYellow;
	public GameObject PanelViolet;
	public GameObject PanelPinc;
	public GameObject PanelWhite;
	public GameObject PanelBrown;

	public GameObject MainMenu;
	public GameObject PanelBird;
	public GameObject PanelMaps;
	public GameObject PanelBirdColor;
	public GameObject PanelBirdArmor;

	public int LevelLoad;
	public int LevelLoad2;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (MainMenu.activeSelf == true) {
			Time.timeScale = 0;

		}
		if (Input.GetKeyDown (KeyCode.E)) 
		{
			PlayerPrefs.SetInt("SaveMaps", 0 );
			PlayerPrefs.SetInt("SaveBird", 0 );
		}


		if (LevelLoad2 >= 1) {
			PlayerPrefs.SetInt ("SaveMaps", LevelLoad2);
			PlayerPrefs.Save ();
			Debug.Log ("SaveMaps");
		}
		LevelLoad2 = PlayerPrefs.GetInt ("SaveMaps");

		if (LevelLoad >= 1 && PanelBird.activeSelf == false) {
			MainMenu.SetActive (false);
		}
		if(LevelLoad >= 1 && PanelBird.activeSelf == true){
			PlayerPrefs.SetInt ("SaveBird", LevelLoad);
			PlayerPrefs.Save ();
			Debug.Log ("SaveBird");
		}
		LevelLoad = PlayerPrefs.GetInt ("SaveBird");



		if (LevelLoad == 1) {
			BirdBlue.SetActive (true);
			PanelBlue.SetActive (true);
			fly_Blue.SetActive (true);
		}
		if (LevelLoad == 2) {
			BirdRed.SetActive (true);
			PanelRed.SetActive (true);
			fly_Red.SetActive (true);
		}
		if (LevelLoad == 3) {
			BirdGreen.SetActive (true);
			PanelGreen.SetActive (true);
			fly_Green.SetActive (true);
		}
		if (LevelLoad == 4) {
			BirdYellow.SetActive (true);
			PanelYellow.SetActive (true);
			fly_Yellow.SetActive (true);
		}
		if (LevelLoad == 5) {
			BirdWhite.SetActive (true);
			PanelWhite.SetActive (true);
			fly_White.SetActive (true);
		}
		if (LevelLoad == 6) {
			BirdPinc.SetActive (true);
			PanelPinc.SetActive (true);
			fly_Pinc.SetActive (true);
		}
		if (LevelLoad == 7) {
			BirdViolet.SetActive (true);
			PanelViolet.SetActive (true);
			fly_Violet.SetActive (true);
		}
		if (LevelLoad == 8) {
			BirdBrown.SetActive (true);
			PanelBrown.SetActive (true);
			fly_Brown.SetActive (true);
		}
		if (LevelLoad == 9) {
			BirdWhiteArmor.SetActive (true);
			PanelWhite.SetActive (true);
			fly_WhiteArmor.SetActive (true);
		}
		if (LevelLoad == 10) {
			BirdBlueArmor.SetActive (true);
			PanelBlue.SetActive (true);
			fly_BlueArmor.SetActive (true);
		}
		if (LevelLoad == 11) {
			BirdGreenArmor.SetActive (true);
			PanelGreen.SetActive (true);
			fly_GreenArmor.SetActive (true);
		}
		if (LevelLoad == 12) {
			BirdPincArmor.SetActive (true);
			PanelPinc.SetActive (true);
			fly_PincArmor.SetActive (true);
		}
		if (LevelLoad == 13) {
			BirdVioletArmor.SetActive (true);
			PanelViolet.SetActive (true);
			fly_VioletArmor.SetActive (true);
		}
		if (LevelLoad == 14) {
			BirdYellowArmor.SetActive (true);
			PanelYellow.SetActive (true);
			fly_YellowArmor.SetActive (true);
		}
		if (LevelLoad == 15) {
			BirdRedArmor.SetActive (true);
			PanelRed.SetActive (true);
			fly_RedArmor.SetActive (true);
		}
		if (LevelLoad == 16) {
			BirdBrownArmor.SetActive (true);
			PanelBrown.SetActive (true);
			fly_BrownArmor.SetActive (true);
		}
		if (LevelLoad2 == 1) {
			MapMountinBlue.SetActive (true);
		}
		if (LevelLoad2 == 2) {
			MapMountinYellow.SetActive (true);
		}
		if (LevelLoad2 == 3) {
			MapMountinGreen.SetActive (true);
		}
		if (LevelLoad2 == 4) {
			MapMountinViolet.SetActive (true);
		}
		if (LevelLoad2 == 5) {
			MapDezertBlue.SetActive (true);
		}
		if (LevelLoad2 == 6) {
			MapDezertGreen.SetActive (true);
		}
		if (LevelLoad2 == 7) {
			MapDezertViolet.SetActive (true);
		}
		if (LevelLoad2 == 8) {
			MapMountinYellow.SetActive (true);
		}

	}
	public void OnClickBirdblue ()
	{
		BirdBlue.SetActive (true);
		PanelMaps.SetActive (true);
		PanelBlue.SetActive (true);
		LevelLoad = 1;
	}
	public void OnClickBirdRed ()
	{
		BirdRed.SetActive (true);
		PanelMaps.SetActive (true);
		PanelRed.SetActive (true);
		LevelLoad = 2;
	}
	public void OnClickBirdGreen ()
	{
		BirdGreen.SetActive (true);
		PanelMaps.SetActive (true);
		PanelGreen.SetActive (true);
		LevelLoad = 3;
	}
	public void OnClickBirdYellow ()
	{
		BirdYellow.SetActive (true);
		PanelMaps.SetActive (true);
		PanelYellow.SetActive (true);
		LevelLoad = 4;
	}
	public void OnClickBirdWhite ()
	{
		BirdWhite.SetActive (true);
		PanelMaps.SetActive (true);
		PanelWhite.SetActive (true);
		LevelLoad = 5;
	}
	public void OnClickBirdPinc ()
	{
		BirdPinc.SetActive (true);
		PanelMaps.SetActive (true);
		PanelPinc.SetActive (true);
		LevelLoad = 6;
	}
	public void OnClickBirdViolet ()
	{
		BirdViolet.SetActive (true);
		PanelMaps.SetActive (true);
		PanelViolet.SetActive (true);
		LevelLoad = 7;
	}
	public void OnClickBirdBrown ()
	{
		BirdBrown.SetActive (true);
		PanelMaps.SetActive (true);
		PanelBrown.SetActive (true);
		LevelLoad = 8;
	}
	public void OnClickBirdWhiteArmor ()
	{
		BirdWhiteArmor.SetActive (true);
		PanelMaps.SetActive (true);
		PanelWhite.SetActive (true);
		LevelLoad = 9;
	}
	public void OnClickBirdBlueArmor ()
	{
		BirdBlueArmor.SetActive (true);
		PanelMaps.SetActive (true);
		PanelBlue.SetActive (true);
		LevelLoad = 10;
	}
	public void OnClickBirdGreenArmor ()
	{
		BirdGreenArmor.SetActive (true);
		PanelMaps.SetActive (true);
		PanelGreen.SetActive (true);
		LevelLoad = 11;
	}
	public void OnClickBirdPincArmor ()
	{
		BirdPincArmor.SetActive (true);
		PanelMaps.SetActive (true);
		PanelPinc.SetActive (true);
		LevelLoad = 12;
	}
	public void OnClickBirdVioletArmor ()
	{
		BirdVioletArmor.SetActive (true);
		PanelMaps.SetActive (true);
		PanelViolet.SetActive (true);
		LevelLoad = 13;
	}
	public void OnClickBirdYellowArmor ()
	{
		BirdYellow.SetActive (true);
		PanelMaps.SetActive (true);
		PanelYellow.SetActive (true);
		LevelLoad = 14;
	}
	public void OnClickBirdRedArmor ()
	{
		BirdRedArmor.SetActive (true);
		PanelMaps.SetActive (true);
		PanelRed.SetActive (true);
		LevelLoad = 15;
	}
	public void OnClickBirdBrownArmor ()
	{
		BirdBrownArmor.SetActive (true);
		PanelMaps.SetActive (true);
		PanelBrown.SetActive (true);
		LevelLoad = 16;
	}
	public void OnClickMapMauntinBlue ()
	{
		MapMountinBlue.SetActive (true);
		PanelMaps.SetActive (false);
		MainMenu.SetActive (false);
		PanelBird.SetActive (false);
		PanelBirdArmor.SetActive (false);
		PanelBirdColor.SetActive (false);
		LevelLoad2 = 1;

	}
	public void OnClickMapMauntinYellow ()
	{
		MapMountinYellow.SetActive (true);
		PanelMaps.SetActive (false);
		MainMenu.SetActive (false);
		PanelBird.SetActive (false);
		PanelBirdArmor.SetActive (false);
		PanelBirdColor.SetActive (false);
		LevelLoad2 = 2;
	}
	public void OnClickMapMauntinGreen ()
	{
		MapMountinGreen.SetActive (true);
		PanelMaps.SetActive (false);
		MainMenu.SetActive (false);
		PanelBird.SetActive (false);
		PanelBirdArmor.SetActive (false);
		PanelBirdColor.SetActive (false);
		LevelLoad2 = 3;
	}
	public void OnClickMapMauntinViolet ()
	{
		MapMountinViolet.SetActive (true);
		PanelMaps.SetActive (false);
		MainMenu.SetActive (false);
		PanelBird.SetActive (false);
		PanelBirdArmor.SetActive (false);
		PanelBirdColor.SetActive (false);
		LevelLoad2 = 4;
	}
	public void OnClickMapDezertBlue()
	{
		MapDezertBlue.SetActive (true);
		PanelMaps.SetActive (false);
		MainMenu.SetActive (false);
		PanelBird.SetActive (false);
		PanelBirdArmor.SetActive (false);
		PanelBirdColor.SetActive (false);
		LevelLoad2 = 5;
	}
	public void OnClickMapDezertGreen ()
	{
		MapDezertGreen.SetActive (true);
		PanelMaps.SetActive (false);
		MainMenu.SetActive (false);
		PanelBird.SetActive (false);
		PanelBirdArmor.SetActive (false);
		PanelBirdColor.SetActive (false);
		LevelLoad2 = 6;
	}
	public void OnClickMapDezertViolet ()
	{
		MapDezertViolet.SetActive (true);
		PanelMaps.SetActive (false);
		MainMenu.SetActive (false);
		PanelBird.SetActive (false);
		PanelBirdArmor.SetActive (false);
		PanelBirdColor.SetActive (false);
		LevelLoad2 = 7;
	}
	public void OnClickMapDezertYellow ()
	{
		MapDezertYellow.SetActive (true);
		PanelMaps.SetActive (false);
		MainMenu.SetActive (false);
		PanelBird.SetActive (false);
		PanelBirdArmor.SetActive (false);
		PanelBirdColor.SetActive (false);
		LevelLoad2 = 8;
	}
	public void OnClickPlayGame ()
	{
		PanelBird.SetActive (true);
	}
	public void OnClickBirdColor ()
	{
		PanelBirdColor.SetActive (true);
	}
	public void OnClickBirdArmor ()
	{
		PanelBirdArmor.SetActive (true);
	}
	public void OnClickMainMenu ()
	{
		PlayerPrefs.SetInt("SaveMaps", 0 );
		PlayerPrefs.SetInt("SaveBird", 0 );
		Application.LoadLevel (0);
	}
}
