using UnityEngine;
using System.Collections;

// Bossa Antigua by Kevin MacLeod | https://incompetech.com/
// Music promoted by https://www.chosic.com/free-music/all/
// Creative Commons Creative Commons: By Attribution 3.0 License
// http://creativecommons.org/licenses/by/3.0/

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    public float jumpingPower = 8f;

    public float fallForce = -10f;
    private bool isFacingRight = true;
    public Animator animator;

    private bool isAttacking = false;
    private float attackTime = .25f;
    private float timer = 0;
    private GameObject attackArea;

    private GameObject currentOneWayPlatform;
    [SerializeField] private BoxCollider2D playerCollider;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private AudioSource collectAudio;


    [SerializeField] AudioSource attackAudio;

    //Hide Code
    private bool isHidden = false;
    private bool canHide = true;
    public float hideTime = 1.5f;
    private float hideTimer = 0f;
    public float hideCoolDownTime = 2f;
    private SpriteRenderer sr;

    void Start()
    {
        attackArea = transform.GetChild(1).gameObject;
        sr = GetComponent<SpriteRenderer>();
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

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentOneWayPlatform != null)
            {
                Debug.Log("Going down!");
                StartCoroutine(DisableCollision());
            }
        }

        if (Input.GetKeyDown(KeyCode.Q)){
            if(canHide){
                isHidden = true;
                animator.SetBool("IsHidden", true);
                //sr.color = new Color(1f, 1f, 1f, .5f);
                canHide = false;
                // GetComponent<BoxCollider2D>().enabled = false;
                gameObject.tag = "HiddenPlayer";
            }
        }

        if(isHidden){
            hideTimer += Time.deltaTime;
            if (hideTimer >= hideTime){
                hideTimer = 0;
                isHidden = false;
                animator.SetBool("IsHidden", false);
                //sr.color = new Color(1f, 1f, 1f, 1f);
                // GetComponent<BoxCollider2D>().enabled = false;
                gameObject.tag = "Player";
                Light.Hidden();
            }
        }

        if(!canHide){
            hideTimer += Time.deltaTime;
            if(hideTimer >= hideCoolDownTime){
                hideTimer = 0;
                canHide = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.RightShift)){
            Attack();
        }

        if(isAttacking){
            timer += Time.deltaTime;
            attackAudio.Play(0);
            if(timer >= attackTime){
                timer = 0;
                isAttacking = false;
                animator.SetBool("IsAttacking", isAttacking);
                attackArea.SetActive(false);
            }
        }

        if(IsGrounded()){
            animator.SetBool("IsJumping", false);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        rb.AddForce(new Vector3(0,fallForce,0), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.75f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag.Contains("Fruit")) {
            Destroy(collision.gameObject);
            GameData.crossOut(collision.gameObject.tag.Split("_")[1]);
            //cm.coinCount++;
            collectAudio.Play(0);
        }
    }
}