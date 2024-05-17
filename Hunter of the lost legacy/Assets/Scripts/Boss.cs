using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Boss : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    private Camera mainCamera;
    private Rigidbody rb;
    public float Xspeed;
    public float Yspeed;
    public float Zspeed;
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }
    void Update()
    {
        if (!IsInsideCameraView())
        {
        }
        else
        {
            Vector3 movement = new Vector3(Xspeed, Yspeed, Zspeed);
            rb.velocity = movement;
        }
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Victory Scene");
        }
    }
    bool IsInsideCameraView()
    {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);
        return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1 && screenPoint.z > 0;   
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(20);
        }
    }
}