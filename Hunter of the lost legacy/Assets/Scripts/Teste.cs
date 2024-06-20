using UnityEngine;
using UnityEngine.SceneManagement;
public class Teste : MonoBehaviour
{
    public GameObject pai;
    Rigidbody rb;
    public Transform gun;
    public GameObject bullet;
    float tempoEntreTiros = 3;
    float cronometro;
    public HealthBar healthBar;
    int maxHealth = 100;
    int currentHealth;
    bool dying = true;
    void Start()
    {
        Transform filho = pai.transform.GetChild(0);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        cronometro = tempoEntreTiros;
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Shoot();
        Move();
        Dying();
    }
    void Move()
    {
        if (!Input.GetKey(KeyCode.LeftArrow))
        {
            rb.linearVelocity = Vector3.zero;
        }
        if (!Input.GetKey(KeyCode.RightArrow))
        {
            rb.linearVelocity = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.linearVelocity = Vector3.right * 10;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.linearVelocity = Vector3.left * 10;
        }
    }
    void Shoot()
    {
        cronometro -= Time.deltaTime;
        if (cronometro <= 0f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Instantiate(bullet, gun.position, gun.rotation);
                cronometro = tempoEntreTiros;
            }
        }
    }
    void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (dying)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                TakeDamage(10);
            }
            if (other.gameObject.CompareTag("Enemy"))
            {
                TakeDamage(90);
            }
        }
    }
    void Dying()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            dying = false;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            dying = true;
        }
    }
}