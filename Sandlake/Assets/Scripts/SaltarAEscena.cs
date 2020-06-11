using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaltarAEscena : MonoBehaviour
{
    // Start is called before the first frame update
    Dialogue_Manager dialogoEscena;
    Transform cocinero;
    Transform posicion;
    void Start()
    {
        dialogoEscena = GetComponent<Dialogue_Manager>();
        posicion = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
       
        
                
                
                if (dialogoEscena.contadorConversacion > 0)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void cambiarPosicion()
    {
       
        posicion.position = new Vector2(-21.29f, 87.09f);
    }
}
