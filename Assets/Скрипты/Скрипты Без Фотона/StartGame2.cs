using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame2 : MonoBehaviour
{
    private BirdControl2 Bc;
    private StartGame2 SG;
    public GameObject Tab;
    public MytantManager MM;
    public TimeRewind2 TR2;
    public GameObject Camera;
    public Transform Bird;
    Rigidbody2D rigidbody;

    public float tiltSmooth = 5;

    //public SpriteRenderer SR;
    public float speed = 10f;
    float a = 0;
    bool b = false;
    int SpawnP = 0;
    public Vector3 Vic2;

    Quaternion downRotation;
    Quaternion forwardRotation;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent_StartGame();

        //Bird.rotation = Quaternion.Euler(0, 0, 180);

        if (PlayerPrefs.GetInt("SaveBI") == 1 || PlayerPrefs.GetInt("SaveBI") == 3)
        {
            //Bc.BirdInvers();
            //downRotation = Quaternion.Euler(0, 0, 210);
            //forwardRotation = Quaternion.Euler(0, 0, 150);
            //SR.flipX = true;
            Vic2.x = -0.29f;
            Vic2.z = 0.29f;
            Vic2.y = 0.29f;
            Bird.localScale = Vic2;
            Bird.rotation = Quaternion.Euler(0, 0, 180);
            downRotation = Quaternion.Euler(0, 0, 210);
            forwardRotation = Quaternion.Euler(0, 0, 150);

        }
        else
        {
            downRotation = Quaternion.Euler(0, 0, -50);
            forwardRotation = Quaternion.Euler(0, 0, 30);

            ////Bc.BirdInvers();
            //downRotation = Quaternion.Euler(0, 0, 210);
            //forwardRotation = Quaternion.Euler(0, 0, 150);
            ////SR.flipX = true;
            //Vic2.x = -0.29f;
            //Vic2.z = 0.29f;
            //Vic2.y = 0.29f;
            //Bird.localScale = Vic2;
            ////Bird.transform.rotation = forwardRotation;
        }
        Bc.enabled = false;
        rigidbody.simulated = false;
        MM.enabled = false;
        TR2.enabled = false;
        PlayerPrefs.SetInt("SaveSpawnP", SpawnP);
        //PlayerPrefs.SetInt("SaveTubeColor", 0);
        PlayerPrefs.SetInt("SaveCameraInversia", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && !b)
        {
            FirstFlaps_And_Start();
        }
        if (b) a += Time.deltaTime;
        if (a > 0.1)
        {
            transform.rotation = forwardRotation;
            rigidbody.AddForce(Vector2.up * speed * 50, ForceMode2D.Force);
            a = 0;
            PlayerPrefs.SetInt("SaveSG", 1);
            SG.enabled = false;
        }
    }

    public void GetComponent_StartGame()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Bc = GetComponent<BirdControl2>();
        SG = GetComponent<StartGame2>();
        MM = Camera.GetComponent<MytantManager>();
        //Bird = GetComponent<Transform>();
        //SR = GetComponent<SpriteRenderer>();
    }

    public void FirstFlaps_And_Start()
    {
        Bc.enabled = true;
        rigidbody.simulated = true;
        b = true;
        //if (MM.act == true) MM.enabled = true;
        if (PlayerPrefs.GetInt("SaveMutatorInt") == 1) MM.enabled = false;
        else MM.enabled = true;
        TR2.enabled = true;
        SpawnP = 1;
        PlayerPrefs.SetInt("SaveSpawnP", SpawnP);
        Destroy(Tab);
    }
}
