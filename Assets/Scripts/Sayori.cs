using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private Collider2D coll;

    [Header("�ƶ�����")]
    public float speed;
    float xVelocity;

    [Header("��Ծ����")]
    public float jumpForce;
    int jumpCount;//��Ծ����

    [Header("��Ծ״̬")]
    public bool isOnGround;

    [Header("�������")]
    public LayerMask groundLayer;
    bool jumpPress;//�������

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
        //ת��
        if (xVelocity != 0)
        {
            transform.localScale = new Vector3(xVelocity, 1, 1);
        }
    }
    void IsOnGroundCheck()
    {
        //�жϽ�ɫ��ײ�������ͼ�㷢���Ӵ�
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
        //�ڵ�����
        if (isOnGround == true)
        {
            jumpCount = 1;
        }
        //�ڵ�������Ծ
        if (jumpPress && isOnGround)
        {
            jumpCount--;
            jumpPress = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}