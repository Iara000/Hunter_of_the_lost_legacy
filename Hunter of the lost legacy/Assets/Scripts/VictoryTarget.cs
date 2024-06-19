using UnityEngine;
using UnityEngine.SceneManagement;
public class VictoryTarget : MonoBehaviour
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
        SceneManager.LoadScene("Victory");
    }
}