using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D body;
    [SerializeField] const int SPEED = 15;
    [SerializeField] public bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 500.0f;
    [SerializeField] bool isGrounded = true;

    [SerializeField] Animator animator;

    const int IDLE = 0;
    const int RUN = 1;
    const int JUMP = 2;

    // Start is called before the first frame update.
    void Start(){
        if (body == null) { 
            body = GetComponent<Rigidbody2D>();
        }

        if (animator == null)
            animator = GetComponent<Animator>();
        animator.SetInteger("Movement", IDLE);
    }

    // Update is called once per frame.
    void Update(){
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump")) {
            jumpPressed = true;
        }
    }

    private void FixedUpdate(){
        //Movement in the x-direction.
        body.velocity = new Vector2(SPEED * movement, body.velocity.y);

        //Changes direction the player is facing based on button clicked.
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight){
            Flip();
        }
        if (jumpPressed && isGrounded){
            Jump();
        } else {
            jumpPressed = false;
            if (isGrounded) {
                if (movement > 0 || movement < 0)
                {
                    animator.SetInteger("Movement", RUN);
                }
                else
                {
                    animator.SetInteger("Movement", IDLE);
                }
            }
        }
    }

    //Transform in the y direction which flips the sprite.
    private void Flip(){
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    //Player jumps
    private void Jump()
    {
        animator.SetInteger("Movement", JUMP);
        body.velocity = new Vector2(body.velocity.x, 0);
        body.AddForce(new Vector2(0, jumpForce));
        jumpPressed = false;
        isGrounded = false;
    }

    //Detects if player is on the ground.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground"){
            isGrounded = true;
        }
        if (collision.gameObject.tag == "Rock"){
            isGrounded = true;
        }
        animator.SetInteger("Movement", IDLE);
    }
}
