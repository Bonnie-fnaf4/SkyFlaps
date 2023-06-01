using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlan2 : MonoBehaviour
{
    [SerializeField] GameObject[] Plan = new GameObject[10];
    [SerializeField] int[] sloshnost = new int[10];
    [SerializeField] int intsloshnost = 1;
    public int a, b, c;
    public Transform Spawn;
    int SpawnP = 0;
    // Start is called before the first frame update
    void Start()
    {
        c = -1;
        intsloshnost = PlayerPrefs.GetInt("SaveintSloshnost");
        intsloshnost -= 1;
        a = sloshnost[intsloshnost];
        if (intsloshnost == 0) b = 0;
        else b = sloshnost[intsloshnost - 1];
    }
    // Update is called once per frame
    void Update()
    {
        SpawnP = PlayerPrefs.GetInt("SaveSpawnP");
        while (SpawnP == 1)
        {
            int i = Random.Range(b, a);
            while (c == i && !(i == 0))
            {
                i = Random.Range(b, a);
            }
            c = i;
            Vector3 Pos = Spawn.position;
            Instantiate(Plan[i], Pos, Quaternion.identity);
            SpawnP = 0;
            PlayerPrefs.SetInt("SaveSpawnP", SpawnP);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "SpawnP")
        {
            SpawnP = 1;
            PlayerPrefs.SetInt("SaveSpawnP", SpawnP);
        }
    }
}
