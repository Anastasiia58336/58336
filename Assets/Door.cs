using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Door : MonoBehaviour
{
    public string nextSceneName; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null && inventory.hasKey)
            {
                Debug.Log("Door is opened!");
                Destroy(gameObject); 
            }
            else
            {
                Debug.Log("Door is locked. Need a key");
            }
        }
    }
}