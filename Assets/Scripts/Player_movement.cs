using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Player_movement : MonoBehaviour
{
    public float speed = 5.5f;
    public float jumpforce = 2f;
    private float horizontal;
    private Transform playerTransform;
    private Rigidbody2D rb;
    public Animator animatronix;
    public bool isGrounded;


    public PlayableDirector director;


    private void Awake() {
        
        rb = GetComponent<Rigidbody2D>();
        animatronix = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();

    }
 
    //Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        
         if (horizontal == 1)
        {   
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animatronix.SetBool("run", true);
        }      
        else if (horizontal == -1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animatronix.SetBool("run", true);
        }
        else 
        {
            animatronix.SetBool("run", false);
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            animatronix.SetBool("jump", true);
        }
        
        
    }
     void FixedUpdate() {

        
        //la velocidad del Rigidbody es un vector que en el eje X, mueves en horizontal dependiendo de la velocidad(multiplica)
        rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);    

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Cinematica")  
        {
            director.Play();
        }
    }  
} 