using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public bool isGrounded;
    public Transform groundedEnd;
    public Animator animator;
    private float horizontalMove = 0f;
    private bool canDoubleJump;
    public bool bootsPowerUp;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        isGrounded = false;
        bootsPowerUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        JumpSystem();
        MovementSystem();
    }

    void JumpSystem()
    {
        isGrounded = Physics2D.Linecast(this.transform.position, groundedEnd.position, 1 << LayerMask.NameToLayer("Ground"));
        Debug.DrawLine(this.transform.position, groundedEnd.position, Color.green);

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
                animator.SetBool("Jumping", false);
            }
            else
            {
                if (bootsPowerUp && canDoubleJump)
                {
                    rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
                    animator.SetBool("Jumping", false);
                    canDoubleJump = false;
                }
            }
        }
        if (isGrounded)
        {
            animator.SetBool("Jumping", false);
            canDoubleJump = true;
        }
        if(!isGrounded)
        {
            animator.SetBool("Jumping", true);
        }
    }

    void MovementSystem()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Running", true);
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Running", true);
            transform.eulerAngles = new Vector2(0, 180);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Running", false);
           
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Running", false);
            
        }

    }

   
}
