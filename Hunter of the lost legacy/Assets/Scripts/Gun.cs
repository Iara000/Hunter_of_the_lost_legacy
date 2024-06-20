using UnityEngine;
public class Gun : MonoBehaviour
{
    public GameObject bullet;
    void Start()
    {
        ScheduleNextShot();
    }
    void ScheduleNextShot()
    {
        float randomDelay = Random.Range(0f, 5f);
        Invoke("Shoot", randomDelay);
    }
    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        ScheduleNextShot();
    }
}