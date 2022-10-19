using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    private  Rigidbody2D rb;
    public Animator animatronix;
    //public PlayableDirector director;
    public float speed = 5.5f;
    public bool isGrounded; 
    private float horizontal;
    public float jumpforce = 5f;


    private void Awake() {
        
        rb = GetComponent<Rigidbody2D>();
        animatronix = GetComponent<Animator>();

    }

   
    private void FixedUpdate() {

        
        //la velocidad del Rigidbody es un vector que en el eje X, mueves en horizontal dependiendo de la velocidad(multiplica)
        rb.velocity = new Vector2 (horizontal * speed, 0f);    

    }
 
    //Update is called once per frame
    void Update()
    {
         //playerTransform.position += new Vector3 (1, 0, 0) * horizontal * speed * Time.deltaTime;

         //playerTransform.Translate(Vector3.right * horizontal * speed * Time.deltaTime, Space.World);

        horizontal = Input.GetAxisRaw("Horizontal");


        if(horizontal == 1)
        {

           transform.rotation = Quaternion.Euler(0,0,0);
           animatronix.SetBool("Running", true);
           animatronix.SetBool("Jumping", false);
               
           
           

        }
        else if(horizontal == -1)
        {
            //renderer.flipX = true;
            transform.rotation = Quaternion.Euler(0,180,0);
            animatronix.SetBool("Running", true);
            animatronix.SetBool("Jumping", false);
            
            
            //animatronix.SetBool("Idle", false);
        }
        /*else if(horizontal == 0)
        {
            //renderer.flipX = false;
            animatronix.SetBool("Idle", false);
           animatronix.SetBool("Running", false);
           animatronix.SetBool("Jumping", false);
           
        }*/
        else
        {
            //animatronix.SetBool("Idle", false);
            animatronix.SetBool("Running", false);
            animatronix.SetBool("Jumping", false);
            
        }
    
        if(Input.GetButtonDown("Jump") && isGrounded ) 
        {

            rb.AddForce(Vector2.up * jumpforce  * -2.0f * gravity, ForceMode2D.Impulse); 
            animatronix.SetBool("Jumping", true);
            animatronix.SetBool("Running", false);
            animatronix.SetBool("Idle", false);

        }
        
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Cinematica")  
        {
            director.Play();
        }
    } */  
} 