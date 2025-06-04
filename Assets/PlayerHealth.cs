using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;
    public float flashDuration = 0.1f;
    public int flashCount = 5;
    public GameObject deathUI; 
    public SpriteRenderer[] heartSprites;
    private SpriteRenderer spriteRenderer;
    private bool isDead = false;
    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (deathUI != null)
            deathUI.SetActive(false);
        UpdateHearts();
    }
    public void TakeDamage(int damage)
    {
        if (isDead) return;
        currentHealth -= damage;
        Debug.Log("Player HP: " + currentHealth);
        StartCoroutine(Flash());
        UpdateHearts();
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    IEnumerator Flash()
    {
        for (int i = 0; i < flashCount; i++)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.3f);
            yield return new WaitForSeconds(flashDuration);
            spriteRenderer.color = new Color(1, 1, 1, 1f);
            yield return new WaitForSeconds(flashDuration);
        }
    }
    void UpdateHearts()
    {
        for (int i = 0; i < heartSprites.Length; i++)
        {
            heartSprites[i].enabled = (i < currentHealth);
        }
    }
    void Die()
    {
        isDead = true;
        if (deathUI != null)
            deathUI.SetActive(true);
        gameObject.SetActive(false); 
    }
}