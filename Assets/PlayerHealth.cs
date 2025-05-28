using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void TakeDamge(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player Took Damage" + damage + "Health left" + currentHealth);

        if (currentHealth < 0)
        {
            Die();
        }
    }

        void Die()
        {

            Debug.Log("Player died");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);


        }
}
