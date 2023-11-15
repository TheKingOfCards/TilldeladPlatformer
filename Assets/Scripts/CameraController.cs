using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform playerPos;


    void Update()
    {
        Vector3 followPos = new(playerPos.position.x, playerPos.position.y, -10);

        transform.position = followPos;
    }
}
