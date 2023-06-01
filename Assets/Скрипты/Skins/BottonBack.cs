using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottonBack : MonoBehaviour
{
    public GameObject[] Panel;
    public GameObject MainPanel;
    public bool a;
    // Update is called once per frame
    public void Back()
    {
        a = false;
        for(int i = 0; i < Panel.Length; i++)
        {
            if (Panel[i].activeSelf == true)
            {
                Panel[i].SetActive(false);
                a = true;
            }
        }
        if (!a) MainPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
    }
}
