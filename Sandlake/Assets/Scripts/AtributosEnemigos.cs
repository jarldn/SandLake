//using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtributosEnemigos : MonoBehaviour
{
   
    public int vida;
    public float agua;
    public GameObject effect;
    public int damage = 1;

    [HideInInspector]//no queremos que esta variable salga en el inspector
    public bool golpeado = false;
    public bool isAlive;

   public  AtributosWen atributosPlayer;
    
    void Start()
    {
        isAlive = true;
        atributosPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<AtributosWen>();
    }

    // Update is called once per frame
    void Update()
    {

        if (golpeado)
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;

        }else
        {
            this.GetComponent<SpriteRenderer>().color = Color.white;

        }


        if (vida <= 0)
        {
            if (isAlive)
            {
                Instantiate(effect, transform.position, Quaternion.identity);
                FindObjectOfType<AudioManager>().Play("absorcion");

            }
            isAlive = false;
            //Destroy(gameObject);
        }
    }
    public void Golpe()
    {
        golpeado = true;
        //mirar de poner corutina
        
        vida -= 1;
        
    }

    public void golpeadoNo ()
    {
        golpeado = false;
    }

    public void DestruirEnemigo ()
    {
        atributosPlayer.changeWater(agua);

        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetComponent<AtributosWen>() != null)
        {
            collision.gameObject.GetComponent<AtributosWen>().changeHealth(-damage);



        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<AtributosWen>() != null)
        {
            collision.gameObject.GetComponent<AtributosWen>().changeHealth(-damage);



        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (this.GetComponent<Rigidbody2D>() == null)
        {

            golpeado = false;
        }
    }


}
