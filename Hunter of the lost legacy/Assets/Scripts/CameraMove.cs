using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
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
        Vector3 movement = new Vector3(Xspeed, Yspeed, Zspeed);
        //player.transform.position 
        rb.velocity = movement;
    }
}