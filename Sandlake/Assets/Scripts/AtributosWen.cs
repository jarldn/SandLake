using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtributosWen : MonoBehaviour
{
    CapsuleCollider2D hurtBox;
    int vida;

    // Start is called before the first frame update
    void Start()
    {
        vida = 5;
        hurtBox = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && collision.GetComponent<AtributosEnemigos>() != null)
        {
            vida -= 1;        }
    }



}
