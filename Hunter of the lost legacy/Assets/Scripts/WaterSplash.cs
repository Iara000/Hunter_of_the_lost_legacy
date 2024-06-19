using UnityEngine;
public class WaterSplash : MonoBehaviour
{
    public GameObject Effect;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WaterDetector"))
        {
            Instantiate(Effect, transform.position, transform.rotation);
        }
    }
}