using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WenController : MonoBehaviour
{
    bool isHoldable;

    AtributosWen atributosWen;
    WenSound sonidos;

    public float speed = 5f;
    Rigidbody2D rb;
    Vector2 movement;
    Animator animator;

    int horizontalHash, verticalHash, speedHash, lookXHash, lookYHash, attackHash;//estos ints van a servir para asignar hash a las animaciones

    bool isAttacking = false;
    bool puedeMover = true;


    //float direccionX, direccionY;

    GameObject attackHit;
    bool x;
    bool bloqueo;

    public enum Estados {iddle, andar, hit, attack, hold };

   public Estados estado;

    void Start()
    {
        estado = Estados.iddle;
        sonidos = GetComponent<WenSound>();
        asignarHash();
        rb = GetComponent<Rigidbody2D>();//accedemos al rigidbody
        animator = GetComponent<Animator>();//accedemos al animator
        attackHit = this.transform.GetChild(0).gameObject; //accedemos al hijo attackhit
        attackHit.SetActive(false);//desactivamos por defecto attackHit
        animator.SetFloat(lookYHash, -1);//situamos al personaje mirando hacia abajo
        atributosWen = GetComponent<AtributosWen>();
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
            estado = Estados.andar;
            FindObjectOfType<AudioManager>().Play("walk2");

            //en las siguientes lineas elaboramos un proceso mediante el cual se da preferencia al último eje pulsado cuando los dos ejes son iguales, de forma que cambie la animación si pulsamos las teclas en diagonal y el blend tree no acceda a dos estados a la vez
            
            if (Math.Abs(movement.x) > Math.Abs(movement.y)) //en cada if medimos el tamaño de x e y en valores absolutos, diferenciando cuál es más grande y cambiando la preferencia si se acede a otro eje después
            {
                x = true;
                bloqueo = false;
            }else if (Math.Abs(movement.x) < Math.Abs(movement.y))
            {
                x = false;
                bloqueo = false;
            }
            else if (Math.Abs(movement.x) == Math.Abs(movement.y)&& bloqueo == false)
            {
                x = !x;
                    bloqueo = true;
            }
            animator.SetBool("x", x);

            if (x == true)
            {
                animator.SetFloat(lookXHash, movement.x);
                animator.SetFloat(lookYHash, 0);

            }
            else
            {
                
                animator.SetFloat(lookXHash, 0);
                animator.SetFloat(lookYHash, movement.y);
            }

            //animator.SetFloat(lookXHash, movement.x);
            //animator.SetFloat(lookYHash, movement.y);




        }
        else if ((Mathf.Approximately(movement.x, 0.0f) || Mathf.Approximately(movement.y, 0.0f)))
        {
            estado = Estados.iddle;
            FindObjectOfType<AudioManager>().Pause("walk2");
        }
    
        if (Input.GetButtonDown("Attack") && !isAttacking)
        {
            
            sonidos.soundSource.pitch = UnityEngine.Random.Range(0.8f, 1.2f);//con esto variamos el pitch del sonido de la espada
            sonidos.soundSource.PlayOneShot(sonidos.espada);
            isAttacking = true;
            puedeMover = false;
            animator.SetTrigger(attackHash);
            /*attackHit.SetActive(true);*///activamos el attackHit
          
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            isAttacking = true;

        }
        else if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) //esto son formas de saber que animación está rulando la maquina de estados
        {
            isAttacking = false;
            puedeMover = true;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
        {
            estado = Estados.hit;
        }
        if (isAttacking)
        {
            estado = Estados.attack;
        }

        Debug.Log("hold"+isHoldable);

    }

    void FixedUpdate()// este método sirve para poner todo lo que tiene que ver con físicas
    {

        Debug.Log(estado);
        switch (estado)
        {
            case Estados.iddle:
               
                
                    rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
                    rb.velocity = new Vector2(0, 0);
                
               
                break;

            case Estados.andar:
                if (isHoldable)
                {
                    rb.MovePosition(rb.position);
                    rb.velocity = new Vector2(0, 0);
                }
                else
                {
                    rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
                    rb.velocity = new Vector2(0, 0);
                }
                break;

            case Estados.attack:
                rb.MovePosition(rb.position);
                rb.velocity = new Vector2(0, 0);
                break;

            case Estados.hit:

                break;

            case Estados.hold:
                rb.MovePosition(rb.position);
                rb.velocity = new Vector2(0, 0);
                break;

      

        }

        //rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        //if (puedeMover)
        //{
        //    rb.velocity = movement * speed * Time.fixedDeltaTime;
        //    //rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);//si puede mover se suman los vectores de input de movimiento y la velocidad
        //}
        //else
        //{
        //    //rb.MovePosition(rb.position);//si no puede mover se queda donde está, esto es para que no le afecten fuerzas a posteriori en otros estados como el de atacar
        //}
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

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("item"))
    //    {
    //        isHoldable = true;

    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("item"))
    //    {
    //        isHoldable = true;

    //    }

    //}
}


