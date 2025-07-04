using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HealingPotion : MonoBehaviour
{
    public int healAmount = 1; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null && !playerHealth.IsDead())
            {
                playerHealth.Heal(healAmount);
                Destroy(gameObject); 
            }
        }
    }
}