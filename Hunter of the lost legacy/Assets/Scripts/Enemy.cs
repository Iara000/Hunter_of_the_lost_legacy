using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 Speed;
    private bool isInsideTrigger;
    public GameObject Bullet;
    public Transform Gun;
    public float tempoEntreTiros;
    private float cronometroDeTiro;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cronometroDeTiro = tempoEntreTiros;
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
}