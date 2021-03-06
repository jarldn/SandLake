﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulgonController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    public float speed = 2;
    float timer;

    public AtributosEnemigos atributos;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        timer = 0;
        atributos = GetComponent<AtributosEnemigos>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 3)
        {
            speed *= -1;
            timer = 0;
        }
        if (atributos.isAlive)
        {
            

            if (speed > 0)
            {
                animator.Play("pulgonRight");//Asignamos la animación haci la derecha si la velocidad es mayor que 0 vía script
                                             //Debug.Log("derecha");

            }
            else
            {
                animator.Play("pulgonLeft");
               

            }
        }else
        {
            
            if (speed > 0)
            {
                animator.Play("PulgonMuerteRight");//Asignamos la animación haci la derecha si la velocidad es mayor que 0 vía script
                                             //Debug.Log("derecha");

            }
            else
            {
                animator.Play("PulgonMuerteLeft");
                

            }
            //animator.SetTrigger("Death");
        }

    }

    void FixedUpdate()
    {
        if (!atributos.golpeado)
        {
            Vector2 position = rb.position;
            position.x += speed * Time.fixedDeltaTime;
            rb.MovePosition(position);
        }
    }
}
