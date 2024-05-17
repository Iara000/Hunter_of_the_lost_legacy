using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyGun : MonoBehaviour
{
    private Camera mainCamera;
    public GameObject Bullet;
    public float maxTime;
    float tempo;
    void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        tempo += Time.deltaTime;
        if (!IsInsideCameraView())
        {
        }
        else
        {
            if (tempo > maxTime)
            {
                tempo = 0;
                Instantiate(Bullet, transform.position, Bullet.transform.rotation);
            }
        }
    }
    bool IsInsideCameraView()
    {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);
        return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1 && screenPoint.z > 0;
    }
}