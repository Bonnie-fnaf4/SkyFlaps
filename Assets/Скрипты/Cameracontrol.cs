using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontrol : MonoBehaviour {
    public GameObject Player;
    private Vector3 offset;
	[SerializeField] float leftLimit;
	[SerializeField] float rightLimit;
	[SerializeField] float bottomLimit;
	[SerializeField] float upperLimit;
	Cameracontrol CC;
	AFKKick Afk;
	// Use this for initialization
	void Start () {
        offset = transform.position - Player.transform.position;
		CC = GetComponent<Cameracontrol>();
		Afk = GetComponent<AFKKick>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Player.transform.position + offset;
		transform.position = new Vector3
			(
			Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
			Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
			transform.position.z
			);
	}
	public void Off()
    {
		Afk.enabled = false;
		CC.enabled = false;
    }
}
