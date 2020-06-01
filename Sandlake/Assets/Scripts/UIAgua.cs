using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIAgua : MonoBehaviour
{
    public static UIAgua Instance { get; private set; }

    
    
    Animator animator;

    // Start is called before the first frame update

    void Awake()
    {
        animator = GetComponent<Animator>();
        Instance = this;//instanciamos est objeto
    }
    void Start()
    {
        
       
        
    }

    // Update is called once per frame
    void Update()
    {

        


    }

    public void ActualizaAgua(float agua)
    {

        
        animator.SetFloat("Agua", agua);
        
    }
}
