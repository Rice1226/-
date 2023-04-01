using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private Collider2D coll;

    [Header("移动参数")]
    public float speed;
    float xVelocity;

    [Header("跳跃参数")]
    public float jumpForce;
    int jumpCount;//跳跃次数

    [Header("跳跃状态")]
    public bool isOnGround;

    [Header("环境检测")]
    public LayerMask groundLayer;
    bool jumpPress;//按键检测

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpCount !=0 && isOnGround)
        {
            jumpPress = true;
        }
    }

    void FixedUpdate()
    {
        Move();
        Jump();
        IsOnGroundCheck();
    }
    void Move()
    {
        xVelocity = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);
        float movex = Input.GetAxis("Horizontal");
        if (movex != 0)
        {
            animator.SetBool("WalkBool", true);
        }
        if (movex == 0)
        {
            animator.SetBool("WalkBool", false);
        }
        //转身
        if (xVelocity != 0)
        {
            transform.localScale = new Vector3(xVelocity, 1, 1);
        }
    }
    void IsOnGroundCheck()
    {
        //判断角色碰撞器与地面图层发生接触
        if (coll.IsTouchingLayers(groundLayer))
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
    }
    void Jump()
    {
        //在地面上
        if (isOnGround == true)
        {
            jumpCount = 1;
        }
        //在地面上跳跃
        if (jumpPress && isOnGround)
        {
            jumpCount--;
            jumpPress = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}