using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour { 

    public int health = 5;

    public float flashDuration = 0.1f;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }
    public void TakeDamage(int damage) { 
    

        health -= damage;
        Debug.Log("Enamy took damage. HP: " + health);
        StartCoroutine(FlashRed());

        if(health <= 0)
        {
            Destroy(gameObject);
            FindObjectOfType<MessageUI>().ShowMessage("You killed the enemy!");
     
    }
    }
    System.Collections.IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }
}

