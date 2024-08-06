using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpPower = 0;
    [SerializeField]
    private float maxJump = 10;

    public LayerMask groundLayer;

    bool IsGround;
    bool IsJump;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        IsGround = Physics.Raycast(transform.position, Vector3.down, 0.1f, groundLayer);
        if (!IsGround && Input.GetKey(KeyCode.C))
        {
            jumpPower += 50f * Time.deltaTime;
            Debug.Log("fds");
        }
        if (jumpPower >= maxJump)
        {
            jumpPower = maxJump;
        }
        Jump();
        if (!Input.GetKey(KeyCode.C))
            jumpPower = 0;
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
        }
    }

    public void Move()
    {
            if(Input.GetAxisRaw("Horizontal") > 0)
            {
                rb.velocity= new Vector2(speed, rb.velocity.y);
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

        if(Input.GetKeyUp(KeyCode.C) && !IsGround && !IsJump)
        {
            Debug.Log("afds");
            rb.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            IsJump = true;
        }
    }
}
