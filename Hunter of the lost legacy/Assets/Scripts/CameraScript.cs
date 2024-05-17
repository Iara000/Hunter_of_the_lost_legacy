using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraScript : MonoBehaviour
{
    public Transform player;
    private Bounds cameraBounds;
    void Start()
    {
        CalculateCameraBounds();
    }
    void Update()
    {
        KeepPlayerInBounds();
    }
    void CalculateCameraBounds()
    {
        Camera cam = Camera.main;
        if (cam.orthographic)
        {
            float vertExtent = cam.orthographicSize;
            float horzExtent = vertExtent * Screen.width / Screen.height;
            Vector3 cameraCenter = cam.transform.position;
            Vector3 boundsMin = new Vector3(cameraCenter.x - horzExtent, cameraCenter.y - vertExtent, cameraCenter.z - vertExtent);
            Vector3 boundsMax = new Vector3(cameraCenter.x + horzExtent, cameraCenter.y + vertExtent, cameraCenter.z + vertExtent);
            cameraBounds = new Bounds(cameraCenter, boundsMax - boundsMin);
        }
        else
        {
            Debug.LogError("A câmera não está configurada para projeção ortográfica.");
        }
    }
    void KeepPlayerInBounds()
    {
        Vector3 playerPosition = player.position;
        playerPosition.x = Mathf.Clamp(playerPosition.x, cameraBounds.min.x, cameraBounds.max.x);
        playerPosition.y = Mathf.Clamp(playerPosition.y, cameraBounds.min.y, cameraBounds.max.y);
        playerPosition.z = Mathf.Clamp(playerPosition.z, cameraBounds.min.z, cameraBounds.max.z);
        player.position = playerPosition;
    }
}