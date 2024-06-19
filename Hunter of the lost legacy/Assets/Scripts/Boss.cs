using UnityEngine;
using UnityEngine.SceneManagement;
public class Boss : MonoBehaviour
{
    public float speed;
    public int maxHealth;
    int currentHealth;
    public HealthBar healthBar;
    public ParticleSystem particleEffect;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.right * 0.5f * Time.deltaTime);
    }
    void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth <= 500)
        {
            particleEffect.Play();
        }
        else 
        {
            particleEffect.Stop();
        }
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("VictoryTwo");
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(20);
        }
    }
}