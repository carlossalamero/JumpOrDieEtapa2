using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundchecker : MonoBehaviour
{
     public Player_movement caballero;
     public Animator animatronix;


    void Awake()
    {
         caballero = GameObject.Find("caballero").GetComponent<Player_movement>();
         animatronix = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
         caballero.animatronix.SetBool("Jumping", false);
         caballero.isGrounded = true;
    }


    void OnTriggerStay2D(Collider2D col)
    {
         caballero.isGrounded = true;
        
    }

    void OnTriggerExit2D(Collider2D col)

    {
         caballero.isGrounded = false;
    }
}
