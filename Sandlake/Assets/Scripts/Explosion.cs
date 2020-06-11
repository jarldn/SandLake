using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float duracion = 0;
    AtributosWen atributosWen;
    private ParticleSystem ps;
    void Start()
    {
       atributosWen = GameObject.FindGameObjectWithTag("Player").GetComponent<AtributosWen>();
        ps = GetComponent<ParticleSystem>();
        var trigger = ps.trigger;
        trigger.enabled = true;
        trigger.SetCollider(0, atributosWen.GetComponent<CapsuleCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        FindObjectOfType<AudioManager>().Play("explosion");
        duracion += Time.deltaTime;

        if(duracion > 0.30)
        {
            FindObjectOfType<AudioManager>().Play("explosion");
            Destroy(gameObject);
        }
    }


    //private void OnParticleTrigger()
    //{

    //    atributosWen.changeHealth(-1);
    //}

    private void OnParticleCollision(GameObject other)// Esto se usaría para si queremos que las particulas colisionen con otras cosas, como el player
    {

   
        if (other.GetComponent<AtributosWen>() != null)
        {
            other.GetComponent<AtributosWen>().changeHealth(-1);
        }


    }

}
