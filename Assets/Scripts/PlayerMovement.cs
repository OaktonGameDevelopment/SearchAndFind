using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour //I will be writing comments later
{
    
    public float acceleration;
    public float friction;
    public float jumpSpeed;
    private Rigidbody2D rb2d;
    private bool isGrounded;
    private bool canJump;
    [HideInInspector] public bool wallJump;
    [HideInInspector]public bool dash;
    private bool canDash = false;
    public string secrets = "8:I";
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) canJump = true;
        if (canDash && Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb2d.velocity = Vector2.right * transform.localScale.x * 15 + Vector2.up * 3;
            canDash = false;
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddForce(Vector2.left * acceleration);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddForce(Vector2.right * acceleration);
            transform.localScale = new Vector3(1, 1, 1);
        }
        rb2d.velocity -= new Vector2(friction * rb2d.velocity.x, 0);
        if (canJump)
        {
            RaycastHit2D checkGroundL = Physics2D.Raycast(new Vector3(transform.position.x - transform.localScale.x * 0.5f, transform.position.y, transform.position.z) , Vector2.down, 0.6f);
            RaycastHit2D checkGroundR = Physics2D.Raycast(new Vector3(transform.position.x + transform.localScale.x * 0.5f, transform.position.y, transform.position.z), Vector2.down, 0.6f);
            if ((checkGroundL.collider != null && checkGroundL.collider.CompareTag("Ground")) || (checkGroundR.collider != null && checkGroundR.collider.CompareTag("Ground")))
            {
                rb2d.velocity += Vector2.up * jumpSpeed;
                canJump = false;
            }
            else if (wallJump)
            {
                rb2d.velocity += Vector2.up * jumpSpeed;
                rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Clamp(rb2d.velocity.y, -jumpSpeed, jumpSpeed));
                canJump = false;
            }

        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            if (dash) canDash = true;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            canJump = false;
        }
    }

    public void getWallJump()
    {
        wallJump = true;
    }

    public void getDash()
    {
        dash = true;
    }
}
