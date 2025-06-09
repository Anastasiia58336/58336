using System.Collections;
using System.Collections.Generic;

using UnityEngine;
public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.hasKey = true;            
                Destroy(gameObject);
                FindObjectOfType<MessageUI>().ShowMessage("Key found!");
            }
        }
    }
}