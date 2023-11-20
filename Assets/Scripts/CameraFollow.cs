using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float transitionSpeed = 1f;
    [SerializeField] float yOffSet = 1f;


    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffSet, -10f);

        newPos += Vector3.right * target.localScale.x;
        
        transform.position = Vector3.Slerp(transform.position, newPos, transitionSpeed * Time.deltaTime);

    }
}
