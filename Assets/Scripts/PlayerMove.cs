using UnityEngine;

public class PlayerMove : MonoBehaviour
{   
    public float moveSpeed;
    public float jumpForce;


    private bool isJumping;
    private bool isGrounded;
   

    public Transform GroundCheckL;
    public Transform GroundCheckR;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

   

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(GroundCheckL.position, GroundCheckR.position);
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        
        movePlayer(horizontalMovement);
    }

    void movePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f,jumpForce));
            isJumping = false;
        }
    }

}

