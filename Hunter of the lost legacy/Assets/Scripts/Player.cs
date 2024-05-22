using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    private Rigidbody rb;
    public float Speed;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(Horizontal, 0, Vertical);
        rb.MovePosition(transform.position + movement * Speed * Time.deltaTime);
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
    public void GiveLife(int GiveAmount)
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
        if (other.gameObject.CompareTag("SuperBullet"))
        {
            TakeDamage(100);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(40);
        }
        if (other.gameObject.CompareTag("GL"))
        {
            GiveLife(20);
        }
    }
}