using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    public Transform gun;
    public GameObject bullet;
    public float tempoEntreTiros;
    float cronometro;
    public HealthBar healthBar;
    public int maxHealth;
    public int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        cronometro = tempoEntreTiros;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Shoot();
    }
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed;
        Vector3 move = new Vector3(0, 0, 10 + horizontal);
        rb.linearVelocity = move;
    }
    void Shoot()
    {
        cronometro -= Time.deltaTime;
        if (cronometro <= 0f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
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
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(20);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(80);
        }
    }
}