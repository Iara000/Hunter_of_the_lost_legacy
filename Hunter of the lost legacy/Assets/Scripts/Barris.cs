using UnityEngine;
public class Barris : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    void Start()
    {
        ScheduleNextShot();
    }
    void ScheduleNextShot()
    {
        float randomDelay = Random.Range(0, 5);
        Invoke("SpawnRandomObject", randomDelay);
    }
    void SpawnRandomObject()
    {
        int randomIndex = Random.Range(0, 2);
        if (randomIndex == 0)
        {
            Instantiate(object1, transform.position, transform.rotation);
            ScheduleNextShot();
        }
        else
        {
            Instantiate(object2, transform.position, transform.rotation);
            ScheduleNextShot();
        }
    }
}