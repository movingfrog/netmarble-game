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
    private float jumpLimit = 0.25f;
    float gravity;
    public GameObject effect;

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
        if (!npc1.talking && !npc2.talking)
            Jump();
    }


    private void FixedUpdate()
    {
        if (!npc1.talking && !npc2.talking)
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
            transform.localScale = new Vector2(1, 1);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
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
            gravity = rb.gravityScale;
            rb.gravityScale = 0;
            Debug.Log("점프");
            rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            IsJumping = true;
            IsJump = true;
            jumpTime = 0;
            Instantiate(effect, transform.position, transform.rotation);
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