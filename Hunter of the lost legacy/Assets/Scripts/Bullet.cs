using UnityEngine;
public class Bullet : MonoBehaviour
{
    public Vector3 speed;
    Rigidbody rb;
    void Start()
    {
        Destroy(gameObject, 5);
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        rb.linearVelocity = speed;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}