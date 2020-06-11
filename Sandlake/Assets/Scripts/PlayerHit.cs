using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    WenSound sonidos;

    // Start is called before the first frame update
    void Start()
    {
        sonidos = GetComponentInParent<WenSound>();
    }

    // Update is called once per frame
    void Update()
    {
    

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && collision.gameObject.GetComponent<AtributosEnemigos>() != null)//Comprobamos que la colisión que ha entrado tiene los componentes que llevan los enemigos
        {
           
          
            collision.GetComponent<AtributosEnemigos>().Golpe();
            sonidos.soundSource.pitch = UnityEngine.Random.Range(0.6f, 1.2f);//con esto variamos el pitch del sonido de la espada
            sonidos.soundSource.PlayOneShot(sonidos.golpe);


        }
    }




}
