using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class EnemyNoGun : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 Speed;
    private bool isInsideTrigger;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
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
    void FixedUpdate()
    {
        if (isInsideTrigger)
        {
            rb.MovePosition(transform.position + Speed * Time.deltaTime);
        }
    }
}