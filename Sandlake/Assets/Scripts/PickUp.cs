using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;


    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        
    }


    private void Update()
    {

        
        if (GetComponent<Dialogue_ManagerObjetos>().contadorConversacion == 1)
            Destroy(gameObject); 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other is CapsuleCollider2D)
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull [i] == false)
                {
                    // ITEM CAN BE ADDED TO INVENTORY !
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    
                    break;
                }
            }
        }
    }
}
