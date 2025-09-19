using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float m_Speed = 10f;
    public float m_JumpPower = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Animator anim;
    private Rigidbody2D m_Rigidbody;
    private bool isGrounded;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");
        anim.SetBool("run", xMove != 0);

        m_Rigidbody.linearVelocity = new Vector2(xMove * m_Speed, m_Rigidbody.linearVelocity.y);

        // Flip character based on direction
        if (xMove > 0)
        {
            transform.localScale = new Vector3(3, 3, 3);
        }
        else if (xMove < 0)
        {
            transform.localScale = new Vector3(-3, 3, 3);
        }

        // Check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            m_Rigidbody.AddForce(Vector2.up * m_JumpPower, ForceMode2D.Impulse);
            anim.SetTrigger("jump");
        }
    }
}

