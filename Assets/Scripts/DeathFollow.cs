using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFollow : MonoBehaviour
{
    [SerializeField] Transform target;


    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, -4.5f, 0);

        transform.position = newPos;
    }
}
