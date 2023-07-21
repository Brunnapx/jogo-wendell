using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itenHeart : MonoBehaviour
{
    public int healthValue;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "player")
        {
            //Collision.
        }
    }
}
