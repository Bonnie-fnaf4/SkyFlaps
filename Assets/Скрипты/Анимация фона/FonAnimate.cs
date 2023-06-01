using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FonAnimate : MonoBehaviour
{
    [SerializeField]
    public float speed = 2;
    private Transform back_Transform;
    private float back_Size, back_pos;
    public int intYellow;
    public float y = 9, z = 57;
    // Start is called before the first frame update
    void Start()
    {
        back_Transform = GetComponent<Transform>();
        back_Size = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        intYellow = PlayerPrefs.GetInt("SaveintYellow");
        if(intYellow == 0)
        {
            back_pos += speed * Time.deltaTime;
            back_pos = Mathf.Repeat(back_pos, back_Size);
            back_Transform.position = new Vector3(back_pos, y, z);
        }
        else
        {
            back_pos += -speed * Time.deltaTime;
            back_pos = Mathf.Repeat(back_pos, back_Size);
            back_Transform.position = new Vector3(back_pos, y, z);
        }
        
    }
}
