using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class TestMoney : MonoBehaviourPunCallbacks, IPunObservable
{
    private PhotonView photonView;
    public int money, m2, intID;
    public Text[] m22 = new Text[9];
    public string id;
    //
    public int records, records2;
    public Text[] records22 = new Text[9];
    public Text[] bestRecords;
    public Text UpHostText;
    public int[] best = new int[5], bestId = new int[5];
    public int UpHost = 0, UpHostId = 0;
    //
    public bool HostLeave = false;
    // Start is called before the first frame update
    public Text count, count2;
    //
    bool boolRestart = true;
    float Restart = 0;
    //
    public string name, myname;
    public Text NameHost;
    public bool NameHostBool2 = false;
    public Text NameHostBool2Text;
    public bool NameHostBool = false;
    public bool UpdateHostBool = false;
    private SpawnPlan SP;
    public int SL;

    public bool endTM = true;
    public TimeGameMultiplayer TGM;
    public Transform Bird;
    public GameObject MoneyTextMechPro;
    //public float Timer = 0;
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        SP = GetComponent<SpawnPlan>();
        //if (!NameHostBool2 && PhotonNetwork.PlayerList.Length == 1)
        //{
        //    NameHostBool2 = true;
        //    SP.enabled = true;
        //}
        myname = PhotonNetwork.NickName;
        if (PlayerPrefs.GetInt("HostNameInt") == 1 && (photonView.IsMine))
        {
            NameHostBool2 = true;
            SP.enabled = true;
        }
        if (!(photonView.IsMine)) //Если владелец скрипта не мой то назначить id игроку
        {
            //SP.enabled = false;
            if (PlayerPrefs.GetInt("HostNameInt") == 1)
            {
                name = PhotonNetwork.NickName;
                SL = PlayerPrefs.GetInt("SaveintSloshnost");
                PlayerPrefs.SetString("SaveHostName", name);
                NameHostBool = true;
            }
            for (int i = 2; i <= 10; i++)
            {
                if (PlayerPrefs.GetString("SaveId") == "")
                {
                    id = "2";
                    intID = 2;
                    PlayerPrefs.SetString("SaveId", id);
                    PlayerPrefs.SetString("SaveNick2" + id, photonView.Owner.NickName);
                    return;
                }
                if (PlayerPrefs.GetString("SaveId") == "" + i)
                {
                    intID = i + 1;
                    id = "" + intID;
                    PlayerPrefs.SetString("SaveId", id);
                    PlayerPrefs.SetString("SaveNick2" + id, photonView.Owner.NickName);
                    return;
                }
            }
            return;
        }
        else //Иначе получить данные рекорда и денег
        {
            money = PlayerPrefs.GetInt("SaveMoney");
            records = PlayerPrefs.GetInt("SaveRecords");
            PlayerPrefs.SetString("SaveNick2" + 1, "Вы");
        }
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) //Воид для синхронизации данных
    {
        if (stream.IsWriting) // Территория локального игрока. Тут он отправляет свои данные госддепу и другим игрокам
        {
            stream.SendNext(money);
            stream.SendNext(records);
            stream.SendNext(name);
            stream.SendNext(SL);
            
        }
        else // Территория скрипта которая запускается на копии других игроков которые зашли в ссесию и играют с тобой. К тебе они не какого отношения не имеют. !!! НЕ ПИСАТЬ ТУТ СКРИПТЫ ДЛЯ ЛОКАЛЬНОГО ИГРОКА !!!
        {
            if (!boolRestart) return;
            money = (int)stream.ReceiveNext();
            records = (int)stream.ReceiveNext();
            name = (string)stream.ReceiveNext();
            SL = (int)stream.ReceiveNext();
            
            if (!(name == "")) //Если имя не пустое то изменить значение имён. Это нужно т.к. все игроки скидывают всем своё имя хоста и у только у хоста оно не равно ""
            {
                PlayerPrefs.SetString("SaveHostName", name);
                if(!(SL <= 0)) PlayerPrefs.SetInt("SaveintSloshnost", SL);
            }
            PlayerPrefs.SetInt("SaveM" + id, money);
            PlayerPrefs.SetInt("SaveRecords2" + id, records);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (boolRestart == false) //Запуск таймера глобального обновления списка игроков с их данными
        {
            Restart += Time.deltaTime;
        }
        if (Restart >= 1) //Запуск обновления
        {
            for (int i = 2; i <= 10; i++)
            {
                Restart = 0;
                boolRestart = true;
            }
            ListUpdatePlayer();
        }



        //
        if (!(photonView.IsMine))
        {
            return;
        }
        name = PlayerPrefs.GetString("SaveHostName");
        SL = PlayerPrefs.GetInt("SaveintSloshnost");
        NameHost.text = name + " Сложность - " + SL;
        //
        // if (name == PhotonNetwork.NickName && !NameHostBool2 && Restart >= 1.5)
        //  {
        //    HostUpdate();
        //  }
        // if (!(name == PhotonNetwork.NickName) && NameHostBool2 && Restart >= 1.5)
        // {
        //      SP.enabled = false;
        //     NameHostBool2 = false;
        //     PlayerPrefs.SetInt("SaveHostBug", 1);
        //  }
        // if (Restart >= 1.2)
        // {
        //     Restart = 0;
        //     boolRestart = true;
        // PlayerPrefs.SetInt("SaveHostBug", 0);
        //}
        //if (!(name == PhotonNetwork.NickName) && NameHostBool2)
        //{
        //    SP.enabled = false;
        //   NameHostBool2 = false;
        // }
        // if (PhotonNetwork.PlayerList.Length == 1)
        //  {
        //      NameHostBool2 = true;
        //      SP.enabled = true;
        //  }
        NameHostBool2Text.text = "Я хост? = " + NameHostBool2;
        if (boolRestart)
        {
            for (int i = 2; i <= 10; i++) //Вывод данных и определение лучшего игрока и зама Хоста
            {
                int ii = i - 2;
                m22[ii].text = "Золото Игрока " + PlayerPrefs.GetString("SaveNick2" + i) + " - " + PlayerPrefs.GetInt("SaveM" + i);
                records22[ii].text = "Рекорд Игрока " + PlayerPrefs.GetString("SaveNick2" + i) + " - " + PlayerPrefs.GetInt("SaveRecords2" + i);

                if ((best[4] <= PlayerPrefs.GetInt("SaveRecords2" + i)) && boolRestart) //Это выбор лучших рекордов игроков
                {
                    if ((best[3] <= PlayerPrefs.GetInt("SaveRecords2" + i)) && boolRestart)//Сначало проверяется меньший рекорд, после чего проверяют всё больше и больше
                    {
                        if ((best[2] <= PlayerPrefs.GetInt("SaveRecords2" + i)) && boolRestart)
                        {
                            if ((best[1] <= PlayerPrefs.GetInt("SaveRecords2" + i)) && boolRestart)
                            {
                                if ((best[0] <= PlayerPrefs.GetInt("SaveRecords2" + i)) && boolRestart)
                                {
                                    best[0] = PlayerPrefs.GetInt("SaveRecords2" + i);
                                    PlayerPrefs.SetInt("SaveBestRecords" + 0, best[0]);
                                    bestId[0] = i;
                                }
                                else
                                {
                                    best[1] = PlayerPrefs.GetInt("SaveRecords2" + i); //Тут начинается территория else которые заполняют в случае неудачи предыдущие лучшие рекорды 
                                    PlayerPrefs.SetInt("SaveBestRecords" + 1, best[1]);
                                    bestId[1] = i;
                                }
                            }
                            else
                            {
                                best[2] = PlayerPrefs.GetInt("SaveRecords2" + i);
                                PlayerPrefs.SetInt("SaveBestRecords" + 2, best[2]);
                                bestId[2] = i;
                            }
                        }
                        else
                        {
                            best[3] = PlayerPrefs.GetInt("SaveRecords2" + i);
                            PlayerPrefs.SetInt("SaveBestRecords" + 3, best[3]);
                            bestId[3] = i;
                        }
                    }
                    else
                    {
                        best[4] = PlayerPrefs.GetInt("SaveRecords2" + i);
                        PlayerPrefs.SetInt("SaveBestRecords" + 4, best[4]);
                        bestId[4] = i;
                    }
                    
                }
                if ((UpHost < PlayerPrefs.GetInt("SaveM" + i)) && boolRestart && !(PlayerPrefs.GetString("SaveNick2" + i) == name) && !(name == ""))
                {
                    UpHost = PlayerPrefs.GetInt("SaveM" + i);
                    UpHostId = i;
                }
            }
            //if (best < PlayerPrefs.GetInt("SaveRecords") && boolRestart) //Проверка меня(локального игрока) на лучшего игрока
            //{
            //    best = PlayerPrefs.GetInt("SaveRecords");
            //    PlayerPrefs.SetInt("SaveBestRecords", best);
            //    bestId = 1;
            //}

            int PlayerLenght = PhotonNetwork.PlayerList.Length;

            if ((best[4] <= PlayerPrefs.GetInt("SaveRecords")) && boolRestart) //Это проверка хоста на лучшего игрока
            {
                if ((best[3] <= PlayerPrefs.GetInt("SaveRecords")) && boolRestart) //Сначало проверяется меньший рекорд, после чего проверяют всё больше и больше
                {
                    if ((best[2] <= PlayerPrefs.GetInt("SaveRecords")) && boolRestart)
                    {
                        if ((best[1] <= PlayerPrefs.GetInt("SaveRecords")) && boolRestart)
                        {
                            if ((best[0] <= PlayerPrefs.GetInt("SaveRecords")) && boolRestart)
                            {
                                if (PlayerLenght >= 2)//Эта строчка проверяет есть ли 2 игрока в комнате
                                {
                                    best[0] = PlayerPrefs.GetInt("SaveRecords"); //Эта строчка записывает в Бест[0] значение Рекорда игрока которому пренадлежит скрипт
                                    PlayerPrefs.SetInt("SaveBestRecords" + 0, best[0]); //Эта строчка записывает в сестевые PlayerPrefs значение рекорда игрока который владеет этим скриптом
                                    bestId[0] = 1; //1 Индедификатор игрока который владеет этим скриптом
                                    if (endTM) //bool переменная которая нужна для того что бы эта часть кода не выполнялась большое количесвто раз. Она связанна с другим скриптом а именно с TimeGameMultiplayer
                                    {
                                        if (TGM.end) // Проверка оконченно время или нет
                                        {
                                            PlayerPrefs.SetInt("SaveMoneyText", (best[0] * 3) - best[0]); // Это нужно для текста который появится для игрока как и 3 следующих строки
                                            PlayerPrefs.SetString("SaveMoneyTextString", "Награда за 1 место"); 
                                            PlayerPrefs.SetFloat("SaveMoneyTextFloat", 3);
                                            GameObject g = Instantiate(MoneyTextMechPro, Bird.position, Quaternion.identity); // Спавн текста
                                            Destroy(g, 3);
                                            PlayerPrefs.SetInt("SaveMoney", PlayerPrefs.GetInt("SaveMoney") + (best[0] * 3) - best[0]); //Добавление денег с мультиплеера
                                            endTM = false; // Закртыие bool Переменной
                                        }
                                    }
                                    if (!TGM.end) endTM = true;
                                }
                            }
                            else
                            {
                                if (PlayerLenght >= 2)
                                {
                                    best[1] = PlayerPrefs.GetInt("SaveRecords"); //Тут начинается территория else которые заполняют в случае неудачи предыдущие лучшие рекорды 
                                    PlayerPrefs.SetInt("SaveBestRecords" + 1, best[1]);
                                    bestId[1] = 1;
                                    if (endTM)
                                    {
                                        if (TGM.end)
                                        {
                                            PlayerPrefs.SetInt("SaveMoneyText", (int)(best[1] * 2.5f) - best[1]);
                                            PlayerPrefs.SetString("SaveMoneyTextString", "Награда за 2 место");
                                            PlayerPrefs.SetFloat("SaveMoneyTextFloat", 2.5f);
                                            GameObject g = Instantiate(MoneyTextMechPro, Bird.position, Quaternion.identity);
                                            Destroy(g, 3);
                                            PlayerPrefs.SetInt("SaveMoney", PlayerPrefs.GetInt("SaveMoney") + (int)(best[1] * 2.5f) - best[1]);
                                            endTM = false;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (PlayerLenght >= 4)
                            {
                                best[2] = PlayerPrefs.GetInt("SaveRecords");
                                PlayerPrefs.SetInt("SaveBestRecords" + 2, best[2]);
                                bestId[2] = 1;
                                if (endTM)
                                {
                                    if (TGM.end)
                                    {
                                        PlayerPrefs.SetInt("SaveMoneyText", (best[2] * 2) - best[2]);
                                        PlayerPrefs.SetString("SaveMoneyTextString", "Награда за 3 место");
                                        PlayerPrefs.SetFloat("SaveMoneyTextFloat", 2);
                                        GameObject g = Instantiate(MoneyTextMechPro, Bird.position, Quaternion.identity);
                                        Destroy(g, 3);
                                        PlayerPrefs.SetInt("SaveMoney", PlayerPrefs.GetInt("SaveMoney") + (best[2] * 2) - best[2]);
                                        endTM = false;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (PlayerLenght >= 5)
                        {
                            best[3] = PlayerPrefs.GetInt("SaveRecords");
                            PlayerPrefs.SetInt("SaveBestRecords" + 3, (int)(best[3] * 1.5f) - best[3]);
                            bestId[3] = 1;
                            if (endTM)
                            {
                                if (TGM.end)
                                {
                                    PlayerPrefs.SetInt("SaveMoneyText", best[3]);
                                    PlayerPrefs.SetString("SaveMoneyTextString", "Награда за 4 место");
                                    PlayerPrefs.SetFloat("SaveMoneyTextFloat", 1.5f);
                                    GameObject g = Instantiate(MoneyTextMechPro, Bird.position, Quaternion.identity);
                                    Destroy(g, 3);
                                    PlayerPrefs.SetInt("SaveMoney", PlayerPrefs.GetInt("SaveMoney") + (int)(best[3] * 1.5f) - best[3]);
                                    endTM = false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (PlayerLenght >= 7)
                    {
                        best[4] = PlayerPrefs.GetInt("SaveRecords");
                        PlayerPrefs.SetInt("SaveBestRecords" + 4, best[4]);
                        bestId[4] = 1;
                        if (endTM)
                        {
                            if (TGM.end)
                            {
                                PlayerPrefs.SetInt("SaveMoneyText", (int)(best[4] * 1.25f) - best[4]);
                                PlayerPrefs.SetString("SaveMoneyTextString", "Награда за 5 место");
                                PlayerPrefs.SetFloat("SaveMoneyTextFloat", 1.25f);
                                GameObject g = Instantiate(MoneyTextMechPro, Bird.position, Quaternion.identity);
                                Destroy(g, 3);
                                PlayerPrefs.SetInt("SaveMoney", PlayerPrefs.GetInt("SaveMoney") + (int)(best[4] * 1.25f) - best[4]);
                                endTM = false;
                            }
                        }
                    }
                }

            }
            if (TGM.end) //Обнуление списка лучших рекордов
            {
                PlayerPrefs.SetInt("SaveRecords", 0);
                for (int i = 0; i < 5; i++)
                {
                    PlayerPrefs.SetInt("SaveBestRecords" + i, 0);
                    best[i] = 0;
                    bestId[i] = 0;
                }
                for (int i = 0; i < 10; i++) PlayerPrefs.SetInt("SaveRecords2" + i, 0);
                PlayerPrefs.SetInt("SaveWaitPlayer", 0);
            }
            if (!TGM.end) endTM = true;
            if (UpHost < PlayerPrefs.GetInt("SaveMoney") && boolRestart && !(PhotonNetwork.NickName == name) && !(name == "")) //Такая же проверка но для зама Хоста
            {
                UpHost = PlayerPrefs.GetInt("SaveMoney");
                PlayerPrefs.SetInt("SaveUpHost", UpHost);
                UpHostId = 1;
            }
            for (int i = 0; i < best.Length; i++)
            {
                int ii = i + 1;
                bestRecords[i].text = ii + " " + PlayerPrefs.GetString("SaveNick2" + bestId[i]) + " - " + best[i]; //Вывод информации для разработчика и лучшего игрока
            }
            UpHostText.text = "Зам Хоста " + PlayerPrefs.GetString("SaveNick2" + UpHostId) + " с идексом - " + UpHost;
            count.text = " " + PhotonNetwork.PlayerList.Length;
            count2.text = " " + PhotonNetwork.CurrentRoom.PlayerCount;
            records = PlayerPrefs.GetInt("SaveRecords");
            money = PlayerPrefs.GetInt("SaveMoney");
        }
    }

    public void ListUpdatePlayer() //Воид глобального обновления списка. Тот же принцеп что и при старте скрипта
    {
        if (!(photonView.IsMine))
        {
            if (PlayerPrefs.GetInt("HostNameInt") == 1)
            {
                name = PhotonNetwork.NickName;
                SL = PlayerPrefs.GetInt("SaveintSloshnost");
                PlayerPrefs.SetString("SaveHostName", name);
                NameHostBool = true;
            }
            for (int i = 2; i <= 10; i++)
            {
                if (PlayerPrefs.GetString("SaveId") == "")
                {
                    id = "2";
                    intID = 2;
                    PlayerPrefs.SetString("SaveId", id);
                    PlayerPrefs.SetString("SaveNick2" + id, photonView.Owner.NickName);
                    return;
                }
                if (PlayerPrefs.GetString("SaveId") == "" + i)
                {
                    intID = i + 1;
                    id = "" + intID;
                    PlayerPrefs.SetString("SaveId", id);
                    PlayerPrefs.SetString("SaveNick2" + id, photonView.Owner.NickName);
                    return;
                }
            }
            return;
        }
        else
        {
            money = PlayerPrefs.GetInt("SaveMoney");
            records = PlayerPrefs.GetInt("SaveRecords");
            PlayerPrefs.SetString("SaveNick2" + 1, "Вы");
        }
    }
    public void HostUpdate() //Кнопка проверки обновления Хоста принудительно
    {
        name = PhotonNetwork.NickName;
        PlayerPrefs.SetString("SaveHostName", name);
        PlayerPrefs.SetInt("SaveintSloshnost", SL);
        PlayerPrefs.SetInt("SaveSpawnP", 1);
        NameHostBool2 = true;
        SP.enabled = true;
    }
    public override void OnPlayerLeftRoom(Player otherPlayer) //Если игрок покинул комнату то проверить его на Хоста и начать процесс обновления списка
    {
        //HostUpdate();
        if ((UpHostId == 1) && photonView.IsMine && otherPlayer.NickName == name)
        {
            HostUpdate();
            PlayerPrefs.SetInt("HostNameInt", 1);
        }
        else
        {
            if (photonView.IsMine)
            {
                PlayerPrefs.SetString("SaveHostName", "");
                name = "";
            }
        }
        boolRestart = false;
        UpHost = 0;
        PlayerPrefs.SetString("SaveId", "");
        //if (otherPlayer.NickName == name)
        //{
        //if(UpHostId == 1)
        //{
        // name = PhotonNetwork.NickName;
        //PlayerPrefs.SetString("SaveHostName", name);
        //PlayerPrefs.SetInt("SaveintSloshnost", SL);
        //if (PlayerPrefs.GetInt("SaveSG") == 1) PlayerPrefs.SetInt("SaveSpawnP", 1);
        //}
        //PlayerPrefs.SetString("SaveHostName", PlayerPrefs.GetString("SaveNick2" + UpHostId));
        // if (UpHostId == 1)
        //{
        //  name = PhotonNetwork.NickName;
        //PlayerPrefs.SetString("SaveHostName", name);
        //PlayerPrefs.SetInt("SaveintSloshnost", SL);
        //if (PlayerPrefs.GetInt("SaveSG") == 1) PlayerPrefs.SetInt("SaveSpawnP", 1);
        //SP.enabled = true;
        //}
        //}
        UpHostId = 0;
        for (int i = 2; i <= 10; i++)
        {
            PlayerPrefs.SetInt("SaveM" + i, 0);
            PlayerPrefs.SetInt("SaveRecords2" + i, 0);
            PlayerPrefs.SetString("SaveNick2" + i, "" + i);
        }
    }
}