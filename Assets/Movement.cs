using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float m_Speed = 10f;
    public float m_JumpPower = 10f;
    public float sprintSpeed = 15f;
    public float sprintJumpPower = 15f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Attack_Script attackscript;

    private Animator anim;
    private Rigidbody2D m_Rigidbody;
    private bool isGrounded;
    private bool isSprinting;
    public AudioSource m_JumpAudioSource;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (attackscript != null && attackscript.isAttacking)
        {
            m_Rigidbody.linearVelocity = new Vector2(0, m_Rigidbody.linearVelocity.y);
            anim.SetBool("walk", false);
            anim.SetBool("run", false);
            return;
        }

        float xMove = Input.GetAxisRaw("Horizontal");

        // Check if sprinting
        isSprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        float currentSpeed = isSprinting ? sprintSpeed : m_Speed;
        float currentJumpPower = isSprinting ? sprintJumpPower : m_JumpPower;

        // Movement
        m_Rigidbody.linearVelocity = new Vector2(xMove * currentSpeed, m_Rigidbody.linearVelocity.y);

        // Animation logic
        anim.SetBool("walk", xMove != 0 && !isSprinting);
        anim.SetBool("run", xMove != 0 && isSprinting);

        // Flip character
        if (xMove > 0)
        {
            transform.localScale = new Vector3(3, 3, 3);
        }
        else if (xMove < 0)
        {
            transform.localScale = new Vector3(-3, 3, 3);
        }

        // Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            m_JumpAudioSource.Play();
            m_Rigidbody.AddForce(Vector2.up * currentJumpPower, ForceMode2D.Impulse);
            anim.SetTrigger("jump");
        }
    }
}
