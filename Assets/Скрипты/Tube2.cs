using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube2 : MonoBehaviour {
    public float speed = 3f;
    public GameObject[] prefabs = new GameObject[2];
    public List<GameObject>[] obstacles = new List<GameObject>[2];
    public Transform bird;
    public int intYellow;
    public Transform fix;
    int checkFon;
    public Vector2 direction;
    bool isAdd;
    float a = 0;
    // Use this for initialization
    void Start()
    {
        obstacles[0] = new List<GameObject>();
        intYellow = 0;
        checkFon = 0;
        PlayerPrefs.SetInt("SavecheckFon", checkFon);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        a += Time.deltaTime;
        List<GameObject> top = obstacles[0];
        transform.Translate(direction * Time.deltaTime);
        if ((a > 8) || (checkFon == 0))
        {
            a = 0;
            checkFon = 1;
            PlayerPrefs.SetInt("SavecheckFon", checkFon);
            PlayerPrefs.Save();
            intYellow = PlayerPrefs.GetInt("SaveintYellow");
            if (intYellow == 1)
            {
                speed = -8;
            }
            if (intYellow == 0)
            {
                speed = 8;
            }
            Vector3 position = transform.position;
            int count = obstacles[0].Count;
            isAdd = false;
            if (count > 0)
            {


                for (int i = 0; i < count; i++)
                {
                    top[i].transform.Translate(Vector3.right * -speed * Time.deltaTime);
                }
                if (!isAdd)
                {
                    Vector3 p = fix.transform.position;
                    if (p.x < 595.1)
                    {
                        isAdd = true;
                    }
                }
            }
            else isAdd = true;

            if (isAdd)
            {
                checkFon = 1;
                float between = (1);
                Vector3 pos = new Vector3(-20 + (100), 20 / 2 + (400), 40);
                pos.y += between / 2;
                GameObject obstacle = Instantiate<GameObject>(prefabs[0]);
                obstacle.transform.position = fix.transform.position + Vector3.forward * bird.position.z + Vector3.right;
                obstacles[0].Add(obstacle);


            }
        }
        checkFon = PlayerPrefs.GetInt("SavecheckFon");
        if (checkFon == 0)
        {
            Destroy(top[0]);
            top.RemoveAt(0);
        }

    }

}
