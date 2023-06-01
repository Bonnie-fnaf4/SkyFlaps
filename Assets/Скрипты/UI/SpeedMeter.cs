using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class SpeedMeter : MonoBehaviour
{
    public Rigidbody2D target;
    [Header("UI")]
    public Text speedLabel;
    private float speed = 0.0f;
    private void Update()
    {
        speed = target.velocity.magnitude * 3.6f;
        if (speedLabel != null)
            speedLabel.text = ((int)speed) + " Скорость";
    }
}
