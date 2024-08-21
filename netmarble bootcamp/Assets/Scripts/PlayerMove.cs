using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpPower = 3;
    [SerializeField]
    private float plusJumpPower = 10;
    private float jumpTime = 0;
    private float jumpLimit = 0.1f;
    private float gravity;

    public LayerMask groundLayer;

    bool IsGround;
    bool IsJump;
    bool IsJumping;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        IsGround = Physics.Raycast(transform.position, Vector3.down, 0.1f, groundLayer);
        Jump();
    }


    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            IsJump = false;
            jumpTime = 0;
        }
    }

    public void Move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.C) && !IsGround && !IsJump)
        {
            Debug.Log("점프");
            rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            IsJumping = true;
            IsJump = true;
            jumpTime = 0;
            gravity = rb.gravityScale;
            rb.gravityScale = 0;
        }
        if (IsJumping && Input.GetKey(KeyCode.C))
        {
            Debug.Log("점프중");
            rb.AddForce(new Vector2(0, (jumpPower + plusJumpPower) * Time.deltaTime), ForceMode2D.Impulse);
            jumpTime += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.C) || jumpTime > jumpLimit)
        {
            rb.gravityScale = gravity;
            IsJumping = false;
        }
    }
}
