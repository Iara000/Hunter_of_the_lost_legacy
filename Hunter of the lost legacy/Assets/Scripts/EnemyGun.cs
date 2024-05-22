using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyGun : MonoBehaviour
{
    public GameObject Bullet;
    private bool isInsideTrigger;
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
            isInsideTrigger = false;
        }
    }
    void FixedUpdate()
    {
        if (isInsideTrigger)
        {
            Instantiate(Bullet, transform.position, Bullet.transform.rotation);
        }
    }
}