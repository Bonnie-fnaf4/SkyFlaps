using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlan : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject[] Plan = new GameObject[10];
    [SerializeField] int[] sloshnost = new int[10];
    [SerializeField] int intsloshnost = 1;
    public int a, b, c; //а b нужны для определения границы рандомного выбора замков конкретной сложности
    public bool dis = false;
    public Transform Spawn;
    int SpawnP = 0; //Переменная тригер. При значение 1 Замки спаунятся, при значении 0, нет
    private SpawnPlan SP;
    private TestMoney TM;
    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine) return;
        SP = GetComponent<SpawnPlan>();
        PlayerPrefs.SetInt("SaveSL", sloshnost.Length);
        TM = GetComponent<TestMoney>();
        c = -1;
        intsloshnost = PlayerPrefs.GetInt("SaveintSloshnost");
        if (intsloshnost == 0) //Проверка на клиента. Если да, то скрипт потом в Update себя выключает
        {
            intsloshnost -= 1;
            return;
                }
        intsloshnost -= 1;
        a = sloshnost[intsloshnost];
        if (intsloshnost == 0) b = 0;
        else b = sloshnost[intsloshnost - 1];
    }
    // Update is called once per frame
    void Update()
    {
        // if(intsloshnost == -1)// Ниже 3 if это дополнительная проверка если вдруг клиент стал Хостом. Это нужно т.к. при перезагрузке скрипта, скрипт не начинает работать со старта
        // {
        //     if (PlayerPrefs.GetInt("SaveintSloshnost") > 0) dis = true;
        // }
        if (!photonView.IsMine) return;
        if (TM.NameHostBool2)
        {
            PlayerPrefs.SetInt("SaveSL", sloshnost.Length);
            c = -1;
            intsloshnost = PlayerPrefs.GetInt("SaveintSloshnost");
            if (intsloshnost == 0)
            {
                intsloshnost -= 1;
                return;
            }
            intsloshnost -= 1;
            a = sloshnost[intsloshnost];
            if (intsloshnost == 0) b = 0;
            else b = sloshnost[intsloshnost - 1];
            dis = false;
        }
        else SP.enabled = false;
        if (intsloshnost == -1) SP.enabled = false; //Выключения скрипта при клиенте
        SpawnP = PlayerPrefs.GetInt("SaveSpawnP");
        while (SpawnP == 1)
        {
            int i = Random.Range(b, a);
            while (c == i && !(i == 0)) // Проверка совпадает ли i с предыдущими замками "c". Это нужно что бы замки не спавнились одинаковыми
            {
                i = Random.Range(b, a);
            }
            c = i;
            Vector3 Pos = Spawn.position; // Дальше идёт спав замков у локального игрока и других игроков
            PhotonNetwork.Instantiate(Plan[i].name, Pos, Quaternion.identity);
            SpawnP = 0;
            PlayerPrefs.SetInt("SaveSpawnP", SpawnP);
        }
    }

    void OnCollisionEnter2D(Collision2D col) // Проверка на заканчивание замков
    {
        if (col.gameObject.tag == "SpawnP")
        {
            SpawnP = 1;
            PlayerPrefs.SetInt("SaveSpawnP", SpawnP);
        }
    }
    void OnTriggerEnter2D(Collider2D other) // Проверка на заканчивание замков
    {
        if (other.gameObject.tag == "SpawnP")
        {
            SpawnP = 1;
            PlayerPrefs.SetInt("SaveSpawnP", SpawnP);
        }
    }
}
