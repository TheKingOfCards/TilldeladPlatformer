using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundCheckRadius = .1f;

    float x;
    [SerializeField] int speed = 5;
    [SerializeField] int jumpingPower = 100;
    [SerializeField] float earlyFall = 0.5f;
    bool canJump = true;

    bool isFacingRight = true;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        //X movement
        x = Input.GetAxisRaw("Horizontal");
        
        animator.SetFloat("Speed", Mathf.Abs(x));

        Vector2 movement = new(x, 0);

        Jump();
        Flip();
    }


    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(x * speed * Time.deltaTime * 50, rb2d.velocity.y);
    }


    void Jump()
    {
        if (Input.GetAxisRaw("Jump") > 0 && canJump == true && isGrounded())
        {
            Vector2 jump = Vector2.up * jumpingPower;
            rb2d.AddForce(jump);

            canJump = false;
        }

        if (Input.GetAxisRaw("Jump") == 0)
        {
            canJump = true;

            if(rb2d.velocity.y > 0f)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * earlyFall);
            }
        }
    }


    private void Flip()
    {
        if(isFacingRight && x < 0f || !isFacingRight && x > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1f;
            transform.localScale = scale;
        }
    }


    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);
    }
}
