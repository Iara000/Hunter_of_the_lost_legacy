using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 Vector3;
    private bool isInsideTrigger;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
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
            rb.MovePosition(transform.position + Vector3 * Time.deltaTime);
        }
    }
}