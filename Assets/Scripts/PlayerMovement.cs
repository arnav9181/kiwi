using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 8f;
    private bool isFacingRight = true;
    public Animator animator;

    private bool isAttacking = false;
    private float attackTime = .25f;
    private float timer = 0;
    private GameObject attackArea;



    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        attackArea = transform.GetChild(1).gameObject;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            animator.SetBool("IsJumping", true);

        }

        if(Input.GetKeyDown(KeyCode.RightShift)){
            Attack();
        }

        if(isAttacking){
            timer += Time.deltaTime;

            if(timer >= attackTime){
                timer = 0;
                isAttacking = false;
                animator.SetBool("IsAttacking", isAttacking);
                attackArea.SetActive(false);
            }
        }

        Flip();
    }

    private void Attack()
    {
        isAttacking = true;
        animator.SetBool("IsAttacking", isAttacking);
        attackArea.SetActive(true);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        animator.SetBool("IsJumping", false);
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }


    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}