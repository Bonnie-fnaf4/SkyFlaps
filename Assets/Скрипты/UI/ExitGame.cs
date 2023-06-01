using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public GameObject [] House = new GameObject[0];
    public GameObject Exit;
    public bool all = true;
    public int allint;
    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < House.Length; i++)
        {
            if(House[i].activeSelf == false && allint == 0)
            {
                all = true;
            }
            else
            {
                all = false;
                allint += 1;
            }
        }
        allint = 0;
        if(Input.GetKeyDown(KeyCode.Escape) && all)
        {
            Exit.SetActive(true);
        }
        //all = false;
    }

    public void ExitButton()
    {
        Application.Quit();
    }
    public void CloceExit()
    {
        Exit.SetActive(false);
    }
}
