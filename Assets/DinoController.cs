using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector2 movement;
    [SerializeField] float speed = 5;
    [SerializeField] LayerMask groundLayer;

    [Header("Checks")]
    [SerializeField] Transform cliffCheck;
    [SerializeField] Transform wallCheck;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        movement = new Vector2(speed * 50 * Time.deltaTime, transform.position.y);
        

        Flip();
    }

    void Flip()
    {
        if (NearCliff() || NearWall())
        {
            speed *= -1;
            Vector3 scale = transform.localScale;
            scale.x *= -1f;
            transform.localScale = scale;
        }
    }

    void FixedUpdate()
    {
        rb2d.velocity = movement;
    }

    bool NearCliff()
    {
        return !Physics2D.OverlapCircle(cliffCheck.position, .1f, groundLayer);
    }

    bool NearWall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, .3f, groundLayer);
    }
}
