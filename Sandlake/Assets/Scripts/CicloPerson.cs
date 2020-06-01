using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CicloPerson : MonoBehaviour
{

    float timer;
    public float tiempoCiclo;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
     timer = 0;
     animator = GetComponent<Animator>();
}

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer>tiempoCiclo)
        {
            animator.SetTrigger("Anim");
            timer = 0;
        }
        

        
    }
}
