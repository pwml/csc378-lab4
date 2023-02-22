using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 3f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    public Rigidbody2D rb;
    public Animator animator;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public AudioSource Jumping;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        horizontal = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("speed", Mathf.Abs(horizontal));

        if (Input.GetButtonDown("Jump") && isGrounded()){
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool("isJumping", true);
            Jumping.Play();
        }

        // if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f){
        //    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        //    animator.SetBool("isJumping", false);
        // }

        if (!isGrounded()){
            animator.SetBool("isJumping", false);
        }

        flip();
    }

    // public void OnLanding(){
    //     animator.SetBool("isJumping", false);
    // }

    private void FixedUpdate(){
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void flip(){
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f){
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool isGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
