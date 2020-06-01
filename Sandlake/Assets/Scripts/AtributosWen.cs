using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtributosWen : MonoBehaviour
{
    CapsuleCollider2D hurtBox;
    public int vida;
    public float agua;
    
    int vidaMax=5;
    float aguaMax = 5;
    float aguaAnterior;

    public float timeInvincible = 1.0f;
    bool isInvincible;
    float invincibleTimer;

    // Start is called before the first frame update
    void Start()
    {
        agua = 0;
        vida = vidaMax;
        hurtBox = GetComponent<CapsuleCollider2D>();
        changeWater(agua);
 
    }

    // Update is called once per frame
    void Update()
    {
        if (isInvincible)//si es invencible le restamos tiempo al timer, hasta que baje de cero que lo volvemos a false y deja de ser invulnerable
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    

    public void changeHealth(int cantidad)
    {

        if (cantidad < 0)//si la cantidad es negativa le estamos quitando vida, por lo que hay que comprobar si tiene invulnerabilidad o no
        {
            if (isInvincible)
            {
                return;//si es invencible salimos de la función
            }

            isInvincible = true;//le hacemos incencible y reseteamos el timer de invulnerabilidad
            invincibleTimer = timeInvincible;
        }

        vida =Mathf.Clamp(vida + cantidad, 0 , vidaMax);// le sumamaos la cantidad de vida que demos en el parámetro cantidad, pero debe estar siempre entre 0 y vidaMax;
        //llamamos al método de dar valor a la barra de vida a través de la instancia
//la siguiente línea adapta la barra de vida a su valor actual. Como dividimos la vida entre la vida máxima siempre es un valor entre 0 y 1
        UIHealth.Instance.SetValue(vida / (float)vidaMax);//como los dos números son integers tenemos que cambiar uno de los dos a float para que al dividirlos salga un float

    }

    public void changeWater (float cantidad)
    {
        //aguaAnterior = agua;//con esto guardaríamos el estado del agua anterior
        agua = Mathf.Clamp(agua + cantidad, 0, aguaMax);
        UIAgua.Instance.ActualizaAgua(agua);

    }



}
