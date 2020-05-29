using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] public float fuerzaKnock;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                StartCoroutine(KnockCoroutine(enemy));
            }
        }
    }

    private IEnumerator KnockCoroutine(Rigidbody2D enemy)
    {
       
        Vector2 forceDirection = enemy.transform.position - transform.position;
        Vector2 force = forceDirection.normalized * fuerzaKnock;

        enemy.velocity = force;
        yield return new WaitForSeconds(0.1f);

        
  
        enemy.GetComponent<AtributosEnemigos>().golpeadoNo();
    }
}

