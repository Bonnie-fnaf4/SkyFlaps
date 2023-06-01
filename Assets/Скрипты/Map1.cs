using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map1 : MonoBehaviour
{
    public float speed = 2f;
    public GameObject[] prefabs = new GameObject[2];
    public List<GameObject>[] obstacles = new List<GameObject>[2];
    public Transform bird;

    // Use this for initialization
    void Start()
    {
        obstacles[0] = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        int sw = Screen.width;
        int sh = Screen.height;
        int count = obstacles[0].Count;
        bool isAdd = false;
        if (count > 0)
        {
            List<GameObject> top = obstacles[0];

            for (int i = 0; i < count; i++)
            {
                top[i].transform.Translate(Vector3.right * -speed * Time.deltaTime);

                Vector3 pos = Camera.main.WorldToScreenPoint(top[i].transform.position);
                if (pos.x <= 0)
                {
                    Destroy(top[i]);

                    top.RemoveAt(i);

                    if (--count <= 0)
                    {
                        isAdd = true;
                        break;
                    }
                }
            }
            if (!isAdd)
            {
                Vector3 p = Camera.main.WorldToScreenPoint(top[count - 1].transform.position);
                if (p.x < sw)
                {
                    isAdd = true;
                }
            }
        }
        else isAdd = true;
        if (isAdd && position.y < -5 && position.y > -5.5)
        {
            float between = (-100);
            Vector3 pos = new Vector3(sw + (100), sh / 2 + (50), 40);
            pos.y += between / 2;
            GameObject obstacle = Instantiate<GameObject>(prefabs[0]);
            obstacle.transform.position = Camera.main.ScreenToWorldPoint(pos) + Vector3.forward * bird.position.z + Vector3.right * 49;
            obstacles[0].Add(obstacle);


        }
    }

}
