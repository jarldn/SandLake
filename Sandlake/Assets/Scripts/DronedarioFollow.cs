using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DronedarioFollow : MonoBehaviour
{
    int moveXhash, moveYhash;
    public float speed;
    [SerializeField]
    private Transform target;// Aquí se almacena lo que este game object va a perseguir
    private Rigidbody2D rb;

    bool isMoving;

    Animator animator;
    

    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //Esta sería la forma de obtener el gameObject a través de código, pero lo hemos hecho a través del inspector
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        asignarHash();
    }

    // Update is called once per frame
    void Update()
    {


        if (isMoving)
        {
            animator.SetFloat(moveXhash, target.position.x - rb.position.x);
            animator.SetFloat(moveYhash, target.position.y - rb.position.y);
        }

    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) > 3)
        {

            isMoving = true;
            rb.MovePosition(Vector2.MoveTowards(rb.position, target.position, speed * Time.deltaTime));
            
        }
        else
        {
            isMoving = false;
            rb.MovePosition(rb.position);
        }

        if (Vector2.Distance(transform.position, target.position) > 12)
        {
            rb.GetComponent<CircleCollider2D>().enabled = false;
        }else
        {
            rb.GetComponent<CircleCollider2D>().enabled = true;
        }
    }
    void asignarHash()// con este método le asignamos un hash a los strings de los parámetros del animator, para que no tenga que comparar carácter a carácter y gaste menos procesamiento
    {
        moveXhash = Animator.StringToHash("moveX");
        moveYhash = Animator.StringToHash("moveY");
        

    }
}
