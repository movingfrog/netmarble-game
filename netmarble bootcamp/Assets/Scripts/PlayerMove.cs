using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Animator ani;
    Rigidbody2D rb;
    [SerializeField]
    private float speed = 10f;
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
        ani = GetComponent<Animator>();
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
            ani.SetBool("isJump", false);
            jumpTime = 0;
        }
    }

    public void Move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
            ani.SetBool("isRun", true);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            ani.SetBool("isRun", true);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            ani.SetBool("isRun", false);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.C) && !IsGround && !IsJump)
        {
            gravity = rb.gravityScale;
            rb.gravityScale = 0;
            Debug.Log("Á¡ÇÁ");
            rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            IsJumping = true;
            IsJump = true;
            jumpTime = 0;
            ani.SetBool("isJump", true);
        }
        if (IsJumping && Input.GetKey(KeyCode.C))
        {
            Debug.Log("Á¡ÇÁÁß");
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