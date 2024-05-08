using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float Xspeed;
    public float Yspeed;
    public float Zspeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(Horizontal* Xspeed, Yspeed, Zspeed);
        rb.velocity = movement;
    }
}