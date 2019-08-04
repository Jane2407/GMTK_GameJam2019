using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public Transform player;
    public bool isOldPlayer;
    public float smoothSpeed = 0.125f;
    public Vector3 desiredPosition;

    [SerializeField] public int xOffset = 5;
    [SerializeField] public int yOffset = 7;

    void FixedUpdate()
    {
        if (isOldPlayer)
        {
            if (player.position.x > transform.position.x + xOffset || player.position.x < transform.position.x - xOffset)
            {
                desiredPosition = player.position;
            }

            if (player.position.y > transform.position.y + yOffset || player.position.y < transform.position.y - yOffset)
            {
                desiredPosition = player.position;
            }

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, new Vector3(desiredPosition.x, desiredPosition.y, transform.position.z), smoothSpeed);
            transform.position = smoothedPosition;
        }
        else
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
            isOldPlayer = true;
        }
        
    }
}
