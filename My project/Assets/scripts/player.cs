using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{
    public int health = 3;
    public float Speed;
    public float jumpForce;

    public GameObject Bow;
    public Transform FirePoint;
    
    private bool isJumping;
    private bool doubleJump;
    private bool isFire; 

    private Rigidbody2D rig;
    private Animator anim;

    private float movement;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        GameController.instance.UpdateLives(health);
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        BowFire();
    }

    void FixedUpdate()
    {
        Move();  
    }

    void Move()
    {
        // se nao precionar nada e 0. precionar direita, valoe maximo 1. esquerdar valor maximo -1
        movement = Input.GetAxis("Horizontal");
        

        // adiciona velocidade no corpo do personagem no eixo x e y 
         rig.velocity = new Vector2(movement * Speed, rig.velocity.y);

        if (movement > 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("transition", 1);
            }
            
            transform.eulerAngles = new Vector3(0,0,0);
        }


        if (movement < 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("transition", 1);
            }
            
            transform.eulerAngles = new Vector3(0,180,0);
        }

        if (movement == 0 && !isJumping && !isFire)
        {
            anim.SetInteger("transition", 0);
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                anim.SetInteger("transition", 2);
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                isJumping = true;
            }
            else
            {
                if (doubleJump)
                {
                    anim.SetInteger("transition", 2);
                    rig.AddForce(new Vector2(0, jumpForce * 1), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
           
        }
    }

    void BowFire()
    {
        StartCoroutine("Fire");
    }

    IEnumerator Fire()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isFire = true;
            anim.SetInteger("transition", 3);
            GameObject bow = Instantiate(Bow, FirePoint.position, FirePoint.rotation);

            if (transform.rotation.y == 0)
            {
                bow.GetComponent<bow>().isRight = true;
            }

            if (transform.rotation.y == 180)
            {
                bow.GetComponent<bow>().isRight = false;
            }
            
            isFire = false;
            yield return new WaitForSeconds(0.2f);
            isFire = false;
            anim.SetInteger("transition", 0);
        }
    }

    public void Damage(int dmg)
    {
        health -= dmg;
        GameController.instance.UpdateLives(health);

        if (health <= 0)
        {
            //chamar game over 
            
        }
    }

     void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.layer == 3)
        {
            isJumping = false;
        }
    }
}
