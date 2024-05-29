using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 Speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TriggerZone"))
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + Speed * Time.deltaTime);
    }
}