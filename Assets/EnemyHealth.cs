using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 5;

    public void TakeDamage(int dagame)
    {

        health += dagame;
        Debug.Log("Enamy took damage. HP: " + health);

        if(health <= 0)
        {
            Destroy(gameObject);

        }

    }
}
