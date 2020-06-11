using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryUI;

    Inventory inventory;

    // Use this for initialization
   void Start()
    {
        
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI ()
    {

    }
}
    
