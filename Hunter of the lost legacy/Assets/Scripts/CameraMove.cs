using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Vector3 Speed;
    void FixedUpdate()
    {
        transform.Translate(Speed * Time.deltaTime, Space.World);
    }
}