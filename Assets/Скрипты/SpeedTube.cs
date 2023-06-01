using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTube : MonoBehaviour{
    public Vector2 direction;
    int intYellow;
    int Timer = 0;
    float a = 0;
    bool b = true;
// Start is called before the first frame update
void Start()
    {
        //Time.timeScale = a;
    }

    // Update is called once per frame
    void Update()
    {
       intYellow = PlayerPrefs.GetInt("SaveintYellow");
        if(intYellow == 1)
        {
            transform.Translate(-direction * Time.deltaTime);
        }
        else transform.Translate(direction * Time.deltaTime);
        //if (b)
       //{
           // if (Timer >= 60) a += Time.deltaTime / 280;
          //  if (a >= 0.5) b = false;
           //     }
    }
}
