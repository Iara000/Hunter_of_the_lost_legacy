using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public int maxHealth;
    int currentHealth;
    public HealthBar healthBar;
    Rigidbody rb;
    public float Speed;
    public Transform Gun;
    public GameObject Bullet;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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
        float Horizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(Horizontal, 0, 1);
        rb.MovePosition(transform.position + movement * Speed * Time.deltaTime);
    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet, Gun.position, Gun.rotation);
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
    void GiveLife(int GiveAmount)
    {
        currentHealth += GiveAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
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