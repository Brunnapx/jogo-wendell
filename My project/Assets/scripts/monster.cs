using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    public float speed;
    public float walkTime;
    public bool walkRihgt = true;

    private float timer;
    

    private Rigidbody2D rig;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= walkTime)
        {
            walkRihgt = !walkRihgt;
            timer = 0f;
        }

        if (walkRihgt)
        {
            transform.eulerAngles = new Vector2(0, 180);
            rig.velocity = Vector2.right * speed;
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 0);
            rig.velocity = Vector2.left * speed;
        }
    }
}
