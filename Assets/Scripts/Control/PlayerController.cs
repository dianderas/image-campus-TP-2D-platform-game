using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject character;
    public CharacterData characterData;
    public CharacterTypeVariable currentCharacter;

    [Header("For Movement")]
    public float speed = 10f;
    private bool isWalking;

    [Header("For Dash")]
    public float dashForce = 20f;
    public float dashTime = 0.2f;
    public bool isDashing;
    private bool throwDash;

    [Header("For Jump")]
    public float jumpForce = 5f;
    public LayerMask groundLayer;
    public float collisionRadio;
    public Transform groundCheckPoint;
    public bool isGrounded = true;
    private bool throwJump;
    private bool isJumping;
    public bool canJump = true;
    private float velocityY;

    [Header("For WallSliding")]
    public float wallSlideSpeed = 0f;
    public LayerMask wallLayer;
    public Transform wallCheckPoint;
    public Vector2 wallCheckSize;
    public bool isTouchingWall;
    public bool isWallSliding;
    public bool xAxisHolding;

    [Header("For WallJumping")]
    public float wallJumpForce = 18f;
    public float wallJJumpDirection = -1f;
    public Vector2 wallJumpAngle;

    [Header(" For Sound System")]
    public AudioSource src;
    public int jumpSound;
    public int dashSound;

    private Rigidbody2D rb;
    private Animator animator;
    private float xAxis;
    private float yAxis;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentCharacter.Value = CharacterType.Hihat;
        character = GetCharacter(currentCharacter.Value);
        animator = character.GetComponent<Animator>();
    }

    private void Update()
    {
        //if (health.IsDead()) return;
        //if (InteractWithCombat);
        Inputs();
        CheckWorld();
    }
    private void FixedUpdate()
    {
        InteractWithMovement();
        AnimationControl();
    }
    private void Inputs()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");

        // TODO: TBD refactor to a better design
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            character.SetActive(false);
            currentCharacter.Value = currentCharacter.Value == CharacterType.Hihat ?
                CharacterType.Drums :
                CharacterType.Hihat;
            character = GetCharacter(currentCharacter.Value);
            character.SetActive(true);
            animator = character.GetComponent<Animator>();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            throwJump = true;
            src.PlayOneShot(Camera.main.GetComponent<mixer>().GetSound(jumpSound));
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && isWalking && currentCharacter.Value == CharacterType.Hihat)
        {
            throwDash = true;
            src.PlayOneShot(Camera.main.GetComponent<mixer>().GetSound(dashSound));
        }

        xAxisHolding = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
    }

    private void InteractWithMovement()
    {
        if (isDashing)
        {
            return;
        }

        if (!isWallSliding)
        {
            Walk();
        }

        if (currentCharacter.Value == CharacterType.Hihat)
        {
            WallSlide();
        }


        if (throwJump && isWallSliding)
        {
            animator.SetTrigger("wallJumping");
            WallJump();
        }

        if (throwJump && isGrounded && canJump)
        {
            canJump = false;
            isJumping = true;
            throwJump = false;
            ImproveJump();
            Jump();
        }

        if (throwDash)
        {
            StartCoroutine(Dash());
        }

        velocityY = rb.velocity.y > 0 ? 1 : -1;

        if (isGrounded && velocityY == -1)
        {
            isJumping = false;
        }
    }



    private void ImproveJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (2.5f - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (2.0f - 1) * Time.deltaTime;
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += Vector2.up * jumpForce;
    }

    private void Walk()
    {
        var direction = new Vector2(xAxis, 0);

        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);

        if (direction != Vector2.zero)
        {
            if (!isGrounded)
            {
                isJumping = true;
            }
            else
            {
                isWalking = true;
                isJumping = false;
            }

            if (direction.x < 0 && transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(
                    -transform.localScale.x, transform.localScale.y, transform.localScale.z);
                wallJJumpDirection *= -1;
            }
            else if (direction.x > 0 && transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(
                    Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                wallJJumpDirection *= -1;
            }
        }
        else
        {
            isWalking = false;
        }
    }

    private IEnumerator Dash()
    {
        throwDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashForce, 0f);
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
    }

    private void WallSlide()
    {
        if (isTouchingWall && !isGrounded && rb.velocity.y < 0 && xAxisHolding)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }

        // wall slide
        if (isWallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, wallSlideSpeed);
        }

    }

    private void WallJump()
    {
        var force = new Vector2(wallJumpForce * wallJJumpDirection * wallJumpAngle.x,
            wallJumpForce * wallJumpAngle.y);
        rb.AddForce(force, ForceMode2D.Impulse);
        throwJump = false;
    }

    private void CheckWorld()
    {
        isGrounded = CheckIfGrounded();
        isTouchingWall = CheckIfTouchingWall();
    }
    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckPoint.position, collisionRadio, groundLayer);
    }
    public bool CheckIfTouchingWall()
    {
        return Physics2D.OverlapBox(wallCheckPoint.position, wallCheckSize, 0, wallLayer);
    }
    private void AnimationControl()
    {
        animator.SetFloat("verticalVelocity", velocityY);
        animator.SetBool("jumping", isJumping);
        animator.SetBool("walking", isWalking);

        if (currentCharacter.Value == CharacterType.Hihat)
        {
            animator.SetBool("dashing", isDashing);
            animator.SetBool("sliding", isWallSliding);
        }
    }

    private GameObject GetCharacter(CharacterType type)
    {
        return transform.Find(type.ToString()).gameObject;
    }

    private void OnDrawGizmos()
    {
        // ground check
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPoint.position, collisionRadio);
        // wall check
        Gizmos.color = Color.green;
        Gizmos.DrawCube(wallCheckPoint.position, wallCheckSize);
    }
}
