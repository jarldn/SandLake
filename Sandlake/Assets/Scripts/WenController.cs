using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class WenController : MonoBehaviour
{
   
    
    public float speed = 5f;
    Rigidbody2D rb;
    Vector2 movement;
    Animator animator;

    int horizontalHash, verticalHash, speedHash, lookXHash, lookYHash, attackHash;//estos ints van a servir para asignar hash a las animaciones

    bool isAttacking = false;
    bool puedeMover = true;


    //float direccionX, direccionY;

    GameObject attackHit;

    void Start()
    {

        asignarHash();
        rb = GetComponent<Rigidbody2D>();//accedemos al rigidbody
        animator = GetComponent<Animator>();//accedemos al animator
        attackHit = this.transform.GetChild(0).gameObject; //accedemos al hijo attackhit
        attackHit.SetActive(false);//desactivamos por defecto attackHit
        animator.SetFloat(lookYHash, -1);//situamos al personaje mirando hacia abajo
        //direccionX = animator.GetFloat(lookXHash);
        //direccionY = animator.GetFloat(lookYHash);

    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat(horizontalHash, movement.x);
        animator.SetFloat(verticalHash, movement.y);
        animator.SetFloat(speedHash, movement.sqrMagnitude);//estamos asignando el vector de movimiento (lo que sería la velocidad) al parametro speed.
        
      

        if ((!Mathf.Approximately(movement.x, 0.0f) || !Mathf.Approximately(movement.y, 0.0f)) && puedeMover)//si el vector de movimiento no es 0 en su x o su y (y puede mover es verdadera), cambiamos el parametro look para dejar mirando hacia la dirección correcta
        {
            animator.SetFloat(lookXHash, movement.x);
            animator.SetFloat(lookYHash, movement.y);
            

            
        }
    
        if (Input.GetButtonDown("Attack") && !isAttacking)
        {
            isAttacking = true;
            puedeMover = false;
            animator.SetTrigger(attackHash);

            /*attackHit.SetActive(true);*///activamos el attackHit
          
        }
        // if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) esto sería una forma de saber si una animación se está ejecutando
        //{
        //}


    }

    void FixedUpdate()// este método sirve para poner todo lo que tiene que ver con físicas
    {
        if (puedeMover)
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);//si puede mover se suman los vectores de input de movimiento y la velocidad
        }else
        {
            rb.MovePosition(rb.position);//si no puede mover se queda donde está, esto es para que no le afecten fuerzas a posteriori en otros estados como el de atacar
        }
    }

    void asignarHash()// con este método le asignamos un hash a los strings de los parámetros del animator, para que no tenga que comparar carácter a carácter y gaste menos procesamiento
    {
        horizontalHash = Animator.StringToHash("Horizontal");
        verticalHash = Animator.StringToHash("Vertical");
        speedHash = Animator.StringToHash("Speed");
        lookXHash = Animator.StringToHash("lookX");
        lookYHash = Animator.StringToHash("lookY");
        attackHash = Animator.StringToHash("Attack");

    }
    void endAnimation ()// usamos esta función para enlazarla a los eventos de los clips de animación y saber que el ataque se ha terminado
    {
        isAttacking = false;
        puedeMover = true;
       

        //attackHit.SetActive(false);
        
       
    }
}


