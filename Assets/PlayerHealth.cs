using System.Collections;
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
    public Image[] heartIcons;
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
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        StartCoroutine(Flash());
        UpdateHearts();
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Heal(int amount)
    {
        if (isDead) return;
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHearts();
    }
    public bool IsDead()
    {
        return isDead;
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
        for (int i = 0; i < heartIcons.Length; i++)
        {
            heartIcons[i].enabled = (i < currentHealth);
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