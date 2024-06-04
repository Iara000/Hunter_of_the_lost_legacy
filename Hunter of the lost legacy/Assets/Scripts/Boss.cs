using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Boss : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 Speed;
    private bool isInsideTrigger;
    public GameObject Bullet;
    public Transform Gun;
    public float tempoEntreTiros;
    private float cronometroDeTiro;
    public HealthBar healthBar;
    public int maxHealth = 100;
    public int currentHealth;
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        cronometroDeTiro = tempoEntreTiros;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(20);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            TakeDamage(40);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerZone"))
        {
            isInsideTrigger = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TriggerZone"))
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (isInsideTrigger)
        {
            cronometroDeTiro -= Time.deltaTime;
            if (cronometroDeTiro <= 0f)
            {
                Instantiate(Bullet, Gun.position, Gun.rotation);
                cronometroDeTiro = tempoEntreTiros;
            }
        }
    }
    void FixedUpdate()
    {
        if (isInsideTrigger)
        {
            rb.MovePosition(transform.position + Speed * Time.deltaTime);
        }
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}