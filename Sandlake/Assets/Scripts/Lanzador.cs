using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzador : MonoBehaviour
{
    Animator animator;

    public float tiempoEntreDisparos;
    public float startTiempoEntreDisparos;

    public GameObject proyectil;
    public float rango;

    public Transform player;

    float playerHorizontal;
    float proyectilPosition;

    AtributosEnemigos atributosEnemigos;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        tiempoEntreDisparos = startTiempoEntreDisparos;
        atributosEnemigos = GetComponent<AtributosEnemigos>();
    }

    // Update is called once per frame
    void Update()
    {

        if (atributosEnemigos.isAlive)
        {


            if (Vector2.Distance(transform.position, player.position) < rango)

            {
                if (tiempoEntreDisparos < 0)
                {

                    animator.SetFloat("Horizontal", Mathf.Abs(transform.position.x) - Mathf.Abs(player.position.x));
                    animator.SetTrigger("Disparo");

                    if (Mathf.Abs(transform.position.x) - Mathf.Abs(player.position.x) > 2.5f)
                    {
                        proyectilPosition = 0.6f;

                    }
                    else if ((Mathf.Abs(transform.position.x) - Mathf.Abs(player.position.x) < -2.5f))
                    {
                        proyectilPosition = -0.6f;
                    }
                    else
                    {
                        proyectilPosition = 0;
                    }

                    Instantiate(proyectil, new Vector2(transform.position.x + proyectilPosition, transform.position.y), Quaternion.identity);


                    tiempoEntreDisparos = startTiempoEntreDisparos;
                }
                else
                {
                    tiempoEntreDisparos -= Time.deltaTime;
                }
            }
            else
            {
                tiempoEntreDisparos = -1;
            }
        }
        else
        {
            animator.Play("Planta Muerte");
        }
    }
}
