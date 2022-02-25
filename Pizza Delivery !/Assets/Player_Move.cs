using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Move : MonoBehaviour
{

    [SerializeField] private float movespeed = 10f; //set movespeed
    [SerializeField] private float jumpspeed = 7f; //set jumpspeed
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform FirePoint;

    private float move_H;
    private float move_V;
    private bool ground_check= false;

    private float stamina = 1f;
    private float maxstamina = 1f;

    private bool number = false;

    public Slider slider; 

    private enum movementstate {idle,run,jump,fall} // animation enum

    void start()
    {

    }
    
    void Update()
    {
        animations();
        jump();
        move_H = Input.GetAxisRaw("Horizontal");
        move_V = Input.GetAxisRaw("Vertical");

            if(stamina <= 1 && move_H == 0 || move_H == 1 || move_H == -1 )
            {
              stamina += 0.1f * Time.deltaTime;  
            }

            if(Input.GetKeyDown(KeyCode.D))
         {
            FirePoint.transform.Rotate(0f,0f,0f);
         }
         if(Input.GetKeyDown(KeyCode.A))
         {
            FirePoint.transform.Rotate(0f,180f,0f);
         }
    }
    void FixedUpdate()
    {
        slider.value = stamina; 
        Vector3 movement = new Vector3(move_H,0f,0f);
        transform.position += movement * Time.deltaTime * movespeed;
        
        
    }
     void jump()
    {

        if(ground_check == true && Input.GetButtonDown ("Jump"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,jumpspeed),ForceMode2D.Impulse);
            
            rb.gravityScale = 2.2f;
            number = false;
        }
        if(ground_check == true && Input.GetKeyDown(KeyCode.W))
        {
           if (stamina >= 1f)
           {
            ///Debug.Log(stamina);
            stamina = 0f;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,jumpspeed),ForceMode2D.Impulse);
            rb.gravityScale = 1;
            number = true;
           }
           else
           {
               Debug.Log("low Stamina");
           }
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "ground")
        {
            ground_check = true;
        }
    }
    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.collider.tag == "ground")
        {
            ground_check = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,1f),ForceMode2D.Impulse);
        }
    }

    private void animations()
    {
        movementstate state = 0;

        
        if(move_H == 1 && ground_check == true )
        {
            state = movementstate.run; // set anim
            //gameObject.transform.localScale = new Vector3(1,1,1);
            
        }
        if(move_H == 1 )
        {
            gameObject.transform.localScale = new Vector3(1,1,1);
            
        }
        if(move_H == -1 && ground_check == true )
        {
            state = movementstate.run; // set anim
            //gameObject.transform.localScale = new Vector3(-1,1,1);

        }
        if(move_H == -1)
        {
            gameObject.transform.localScale = new Vector3(-1,1,1);
        }
        if(rb.velocity.y < -1f)
        {
           state = movementstate.fall; // set anim
        }

        if(rb.velocity.y > .1f)
        {
            state = movementstate.jump; // set anim
        }
        
        anim.SetInteger("state",(int)state); 
    }

}