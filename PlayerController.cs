using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    private bool faceRight = true;

    private bool onGround;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Rigidbody2D body;

    public Animator animator;
    public UnityEvent LandingEvent;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("PlayerSpeed", Mathf.Abs(moveInput));
        if (Input.GetKeyDown(KeyCode.UpArrow) && onGround == true)
        {
            body.velocity = Vector2.up * jumpForce;
            animator.SetBool("Jump", true);
        }
        if (body.velocity.y < 0 && onGround == true)
        {
            LandingEvent.Invoke();
        }

    }

    void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(moveInput * speed, body.velocity.y);

        if (faceRight == false && moveInput > 0 || faceRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        faceRight = !faceRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void OnLanding()
    {
        animator.SetBool("Jump", false);
    }
}