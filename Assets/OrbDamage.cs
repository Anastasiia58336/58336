using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OrbDamage : MonoBehaviour
{
    public int damage = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }
    }
}
