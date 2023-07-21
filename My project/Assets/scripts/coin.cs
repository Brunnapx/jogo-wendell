using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public int scoreValue;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameController.instance.UpdateScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
