using System.Collections;
using UnityEngine;
using UnityEngine.UI; 
public class EnemyHealth : MonoBehaviour
{
    public int health = 5;
    public Slider healthSlider; 
    public float flashDuration = 0.1f;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        if (healthSlider != null)
        {
            healthSlider.maxValue = health;
            healthSlider.value = health;
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy took damage. HP: " + health);
        if (healthSlider != null)
        {
            healthSlider.value = health;
        }
        StartCoroutine(FlashRed());
        if (health <= 0)
        {
            FindObjectOfType<MessageUI>()?.ShowMessage("You killed the enemy!");
            Destroy(gameObject);
        }
    }
    IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }
}