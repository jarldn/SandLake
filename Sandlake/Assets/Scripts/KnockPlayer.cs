using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockPlayer : MonoBehaviour
{
    [SerializeField] public float fuerzaKnock;
    

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
           
            Rigidbody2D player= collision.GetComponent<Rigidbody2D>();
            if (player != null)
            {

           
                Vector2 forceDirection = player.transform.position - transform.position;
                Vector2 force = forceDirection.normalized * fuerzaKnock;

                player.velocity = force;

                //StartCoroutine(KnockCoroutine(player));
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {




        Rigidbody2D player = collision.gameObject.GetComponent<Rigidbody2D>();
        if (player != null)
        {

         
            Vector2 forceDirection = player.transform.position - transform.position;
            Vector2 force = forceDirection.normalized * fuerzaKnock;

            player.velocity = force;

            //StartCoroutine(KnockCoroutine(player));
        }
    }



    //private IEnumerator KnockCoroutine(Rigidbody2D player)
    //{
    //    if (player.GetComponent<AtributosWen>() != null)
    //    {
    //        Vector2 forceDirection = player.transform.position - transform.position;
    //        Vector2 force = forceDirection.normalized * fuerzaKnock;

    //        player.velocity = force;

    //        yield return new WaitForSeconds(5f);
    //        Debug.Log("HIT2");
    //        if (player != null)
    //        {
    //            //player.GetComponent<AtributosWen>().golpeado = false;
    //        }

    //    }


    //}
}

