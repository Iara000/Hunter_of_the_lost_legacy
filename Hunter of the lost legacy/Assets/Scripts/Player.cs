using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float Speed;
    private Rigidbody rb;
    public Transform Gun;
    public GameObject Bullet;
    public float tempoEntreTiros;
    float cronometroDeTiro;
    public HealthBar healthBar;
    public int maxHealth;
    int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        cronometroDeTiro = tempoEntreTiros;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Shoot();
    }
    void FixedUpdate()
    {
        move();
    }
    void move()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        Vector3 Move = new Vector3(Horizontal, 0, 1);
        rb.linearVelocity = Move * Speed;
    }
    void Shoot()
    {
        cronometroDeTiro -= Time.deltaTime;
        if (cronometroDeTiro <= 0f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(Bullet, Gun.position, Gun.rotation);
                cronometroDeTiro = tempoEntreTiros;
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
            TakeDamage(40);
        }
    }
}