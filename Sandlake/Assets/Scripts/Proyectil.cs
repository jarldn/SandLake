using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Proyectil : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;

    public GameObject explosion;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);

    }


    void Update()
    {
        transform.Rotate(0, 0, 80*Time.deltaTime, 0);//rotamos el proyectil en z

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            
            DestruirProyectil();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DestruirProyectil();
        }

    }
    void DestruirProyectil()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
