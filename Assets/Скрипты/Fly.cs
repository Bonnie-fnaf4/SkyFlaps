using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
	public GameObject fly_White;
	public GameObject fly_Green;
	public GameObject fly_Blue;
	public GameObject fly_Pinc;
	public GameObject fly_Red;
	public GameObject fly_Violet;
	public GameObject fly_Brown;
	public GameObject fly_Yellow;

	public GameObject White;
	public GameObject Green;
	public GameObject Blue;
	public GameObject Pinc;
	public GameObject Red;
	public GameObject Violet;
	public GameObject Brown;
	public GameObject Yellow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Green == true) 
		{
			fly_Green.SetActive (true);
		}
		if (Green == false) 
		{
			fly_Green.SetActive (false);
		}
		if (Blue == true) 
		{
			fly_Blue.SetActive (true);
		}
		if (Blue == false) 
		{
			fly_Blue.SetActive (false);
		}
		if (Brown == true) 
		{
			fly_Brown.SetActive (true);
		}
		if (Brown == false) 
		{
			fly_Brown.SetActive (false);
		}
		if (Pinc == true) 
		{
			fly_Pinc.SetActive (true);
		}
		if (Pinc == false) 
		{
			fly_Pinc.SetActive (false);
		}
		if (Yellow == true) 
		{
			fly_Yellow.SetActive (true);
		}
		if (Yellow == false) 
		{
			fly_Yellow.SetActive (false);
		}
		if (Violet == true) 
		{
			fly_Violet.SetActive (true);
		}
		if (Violet== false) 
		{
			fly_Violet.SetActive (false);
		}
		if (White == true) 
		{
			fly_White.SetActive (true);
		}
		if (White == false) 
		{
			fly_White.SetActive (false);
		}
		if (Red == true) 
		{
			fly_Red.SetActive (true);
		}
		if (Red == false) 
		{
			fly_Red.SetActive (false);
		}
    }
}
