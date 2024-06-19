using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public Vector3 speed;
    void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime);
    }
}