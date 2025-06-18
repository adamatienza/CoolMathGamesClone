using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float offsetX = 2f;

    void Update()
    {
        if (player != null)
        {
            Vector3 newPos = transform.position;
            newPos.x = player.position.x + offsetX;
            transform.position = newPos;
        }
    }
}
