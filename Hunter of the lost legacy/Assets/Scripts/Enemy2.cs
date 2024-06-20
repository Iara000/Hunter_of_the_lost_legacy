using UnityEngine;
public class EnemyNoGun : MonoBehaviour
{
    public Vector3 Speed;
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        transform.Translate(Speed * Time.deltaTime);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}