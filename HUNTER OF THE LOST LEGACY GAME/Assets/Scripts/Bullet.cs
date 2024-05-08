using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody rb;
    public float Xspeed;
    public float Yspeed;
    public float Zspeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }
    void Update()
    {
        Vector3 movement = new Vector3(Xspeed, Yspeed, Zspeed);
        rb.velocity = movement;
        if (!IsInsideCameraView())
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
    bool IsInsideCameraView()
    {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);
        return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1 && screenPoint.z > 0;
    }
}