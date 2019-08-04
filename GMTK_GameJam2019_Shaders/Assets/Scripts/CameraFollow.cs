using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public Transform player;

    public float smoothSpeed = 0.125f;
    public Vector3 desiredPosition;

    void FixedUpdate()
    {
        if (player.position.x > transform.position.x + 5 || player.position.x < transform.position.x - 5)
        {
            desiredPosition = player.position;
        }
          
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, new Vector3(desiredPosition.x, transform.position.y,transform.position.z), smoothSpeed);
        transform.position = smoothedPosition;

    }
}
