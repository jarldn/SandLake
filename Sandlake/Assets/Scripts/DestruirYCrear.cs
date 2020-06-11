using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirYCrear : MonoBehaviour
{
    Dialogue_Manager dialogoEscena;
    // Start is called before the first frame update
    GameObject[] key;
    GameObject cocinero;
    void Start()
    {
       key =  GameObject.FindGameObjectsWithTag("Key");
         dialogoEscena = GetComponent<Dialogue_Manager>();
        cocinero = GameObject.Find("CocineroCambioEscena");
    }

    // Update is called once per frame
    void Update()
    {



        Debug.Log(key);
        if (dialogoEscena.contadorConversacion > 0)

        {
            key = GameObject.FindGameObjectsWithTag("Key");

            if (key.Length == 0)
            {
                cocinero.GetComponent<SaltarAEscena>().cambiarPosicion();
                Destroy(gameObject);
            }
        }
            
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        key = GameObject.FindGameObjectsWithTag("Key");

    }
}
