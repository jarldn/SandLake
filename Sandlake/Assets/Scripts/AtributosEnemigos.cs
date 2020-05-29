//using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtributosEnemigos : MonoBehaviour
{
   
    public int vida;
    public GameObject effect;

    [HideInInspector]//no queremos que esta variable salga en el inspector
    public bool golpeado = false;
    public bool isAlive;
    
    void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(golpeado);
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
        Destroy(gameObject);
    }

}
