﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlan : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
