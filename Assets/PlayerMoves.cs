using UnityEngine;
public class PlayerMoves : MonoBehaviour
{
    public float MoveSpeed;
    public float jumpForce;

    public bool isJumping;

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    public float horizontalMovement;
    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {;
        PlayerDeplacement(horizontalMovement);
    }


    void Update()
    {

        horizontalMovement = Input.GetAxis("Horizontal") * MoveSpeed * Time.fixedDeltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }


        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
    }

    void PlayerDeplacement(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }
    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}