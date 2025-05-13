using System.Collections;
using UnityEngine;

public class mech_movement : MonoBehaviour
{
    public float leftPosition = -3f;
    public float rightPosition = 3f;
    public float centerPosition = 0f;

    public float snapSpeed = 30f;
    public float jumpForce = 10f;

    private bool isMoving = false;
    private float currentPosition;
    private Rigidbody rb;
    private Animator animator;

    private int jumpCount = 0;
    public int maxJumps = 2;
    private bool wasGroundedLastFrame = false;

    void Start()
    {
        currentPosition = centerPosition;
        transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z);

        rb = GetComponent<Rigidbody>();
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody>();

        rb.constraints = RigidbodyConstraints.FreezeRotation;

        animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.Play("Scene"); // Initial animation
        }
    }

    void Update()
    {
        bool isGrounded = IsGrounded();

        // Reset jump count only when we land
        if (isGrounded && !wasGroundedLastFrame)
        {
            jumpCount = 0;
        }

        wasGroundedLastFrame = isGrounded;

        // LANE SWITCHING
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (currentPosition == centerPosition)
                    StartCoroutine(SnapToPosition(leftPosition));
                else if (currentPosition == rightPosition)
                    StartCoroutine(SnapToPosition(centerPosition));
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (currentPosition == centerPosition)
                    StartCoroutine(SnapToPosition(rightPosition));
                else if (currentPosition == leftPosition)
                    StartCoroutine(SnapToPosition(centerPosition));
            }
        }

        // DOUBLE JUMP
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // Reset vertical velocity
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;

            if (animator != null)
            {
                animator.Play("Scene"); // Optional: Replace with "Jump" if you have a jump animation
            }
        }
    }

    private IEnumerator SnapToPosition(float targetPosition)
    {
        isMoving = true;

        Vector3 startPosition = transform.position;
        Vector3 target = new Vector3(targetPosition, transform.position.y, transform.position.z);

        float journeyLength = Vector3.Distance(startPosition, target);
        float startTime = Time.time;

        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            float distanceCovered = (Time.time - startTime) * snapSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, target, fractionOfJourney);
            yield return null;
        }

        transform.position = target;
        currentPosition = targetPosition;
        isMoving = false;

        if (animator != null)
        {
            animator.Play("Scene"); // Optional: Replace with "Slide" or other
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, 1.2f);
    }
}
