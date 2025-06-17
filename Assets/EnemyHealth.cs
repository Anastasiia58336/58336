using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int health = 5;
    public bool isBoss = false; 
    public Slider healthSlider;
    public float flashDuration = 0.1f;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
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
            ShowDeathMessage();
            Destroy(gameObject);
        }
    }

    void ShowDeathMessage()
    {
        if (isBoss)
        {

            FindObjectOfType<MessageUI>()?.ShowMessage("Congratulations! You killed the boss! \n \n \n  ------ GAME OVER ------", 5f);
        }
        else
        {
            FindObjectOfType<MessageUI>()?.ShowMessage("You killed the enemy!");
        }
    }

    IEnumerator FlashRed()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(flashDuration);
            spriteRenderer.color = originalColor;
        }
    }
}