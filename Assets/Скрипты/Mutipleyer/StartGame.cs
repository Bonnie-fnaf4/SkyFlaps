using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public PhotonView photonView;
    private BirdControl Bc;
    private StartGame SG;
    public GameObject Tab, Tab2;

    //public Text Tabtext;

    public GameObject Number1, Number2;
    public bool Numbder1Bool, Numbder2Bool;

    public Transform Bird;

    Rigidbody2D rigidbody;
    public float speed = 10f;
    float a = 0;
    bool b = false;
    bool c = false;
    int SpawnP = 0;
    TestMoney TM;
    BirdInversionMultiplayer BIM;
    CircleCollider2D CC2D;
    Quaternion downRotation;
    Quaternion forwardRotation;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        rigidbody = GetComponent<Rigidbody2D>();
        Bc = GetComponent<BirdControl>();
        SG = GetComponent<StartGame>();
        TM = GetComponent<TestMoney>();
        BIM = GetComponent<BirdInversionMultiplayer>();
        CC2D = GetComponent<CircleCollider2D>();
        Tab.SetActive(true);
        Bc.enabled = false;
        //rigidbody.simulated = false;
        rigidbody.gravityScale = 0;
        //rigidbody.freezeRotation = true;
        PlayerPrefs.SetInt("SaveSpawnP", SpawnP);
        forwardRotation = Quaternion.Euler(0, 0, 30);
        c = false;
        Numbder1Bool = true;
        Numbder2Bool = true;

        //Tabtext.text = "Jn = " + PlayerPrefs.GetInt("SaveJoinInGame") + " TM = " + TM.NameHostBool2;
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine) return;
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && !b)
        {
            if (!c)
            {
                if (!photonView.IsMine) return;
                Bc.enabled = true;
                //rigidbody.simulated = true;
                b = true;
                PlayerPrefs.SetInt("SpeedTubeDelete", 1);
                SpawnP = 1;
                if (TM.NameHostBool2 && PlayerPrefs.GetInt("SaveJoinInGame") == 1) PlayerPrefs.SetInt("SaveSpawnP", SpawnP);
                Tab.SetActive(false);
                //Tab2.SetActive(false);
                CC2D.isTrigger = false;
                rigidbody.gravityScale = 1;
            }
            else
            {
                if (!photonView.IsMine) return;
                Bc.enabled = true;
                if (BIM.isActiveAndEnabled == true) rigidbody.gravityScale = -1;
                else rigidbody.gravityScale = 1;
                b = true;
                //PlayerPrefs.SetInt("SpeedTubeDelete", 1);
                //SpawnP = 1;
                //if (TM.NameHostBool2) PlayerPrefs.SetInt("SaveSpawnP", SpawnP);
                Tab.SetActive(false);
                Tab2.SetActive(false);
                CC2D.isTrigger = true;
                //if (Bc.Inver2)
                //{ if (speed < 0) { speed = -speed; } }
                //else
                //{ if (speed > 0) { speed = -speed; } }
                transform.rotation = forwardRotation;
                rigidbody.AddForce(Vector2.up * Bc.speed, ForceMode2D.Force);
            }
        }
        //if (!photonView.IsMine) return;
        if (b) a += Time.deltaTime;
        if(Bird.position.y < -12)
        {
            Tab2.SetActive(true);
            rigidbody.gravityScale = 0;
            forwardRotation = Quaternion.Euler(0, 0, 30);
            //SG.enabled = true;
            Bc.enabled = false;
            rigidbody.velocity = new Vector3(0,0);
            b = false;
            a = 0;
            CC2D.isTrigger = false;
            Bird.transform.position = new Vector3(Bird.position.x, -4);
        }
        if (Bird.position.y > 80)
        {
            Tab2.SetActive(true);
            rigidbody.gravityScale = 0;
            rigidbody.velocity = new Vector3(0, 0);
            forwardRotation = Quaternion.Euler(0, 0, 30);
            //SG.enabled = true;
            Bc.enabled = false;
            b = false;
            a = 0;
            CC2D.isTrigger = true;
            Bird.transform.position = new Vector3(Bird.position.x, 72);
        }


        if (a > 0.1)
        {
            if (!c)
            {
                transform.rotation = forwardRotation;
                rigidbody.AddForce(Vector2.up * Bc.speed, ForceMode2D.Force);
                b = false;
                a = 0;
                PlayerPrefs.SetInt("SaveSG", 1);
                SG.enabled = false;
            }
            c = true;
        }
        if (a > 1 && Numbder2Bool)
        {
            GameObject g = Instantiate(Number2, Bird.position, Quaternion.identity);
            Destroy(g, 3);
            Numbder2Bool = false;
        }
        if (a > 2 && Numbder1Bool)
        {
            GameObject g = Instantiate(Number1, Bird.position, Quaternion.identity);
            Destroy(g, 3);
            Numbder1Bool = false;
        }
        if (a > 3)
        {
            CC2D.isTrigger = false;
            b = false;
            a = 0;
            Numbder1Bool = true;
            Numbder2Bool = true;
            //PlayerPrefs.SetInt("SaveSG", 1);
            SG.enabled = false;
        }

    }

   
}