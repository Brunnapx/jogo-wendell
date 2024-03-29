using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<player>().respowCheck = transform.position;
            cam Camera2 = Camera.main.GetComponent<cam>();
            Camera2.Respawn = Camera2.transform.position;
        }
    }
}
