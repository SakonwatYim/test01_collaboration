using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Movement")]
    public float acceleration = 30f;   // a (ความเร่ง)
    public float maxSpeed = 10f;

    [Header("Jump")]
    public float jumpForce = 7f;

    [Header("Camera")]
    public Transform cameraTransform;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckGround();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // ใช้ Impulse สำหรับกระโดด 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward.Normalize();
        camRight.Normalize();

        // รวมทิศ กันวิ่งเฉียงเร็วกว่า
        Vector3 direction = (camForward * v + camRight * h).normalized;

        if (rb.linearVelocity.magnitude < maxSpeed)
        {
            //  F = m * a
            float mass = rb.mass;
            Vector3 force = direction * acceleration * mass;

            rb.AddForce(force, ForceMode.Force);
        }

        Debug.DrawRay(transform.position, Vector3.down * 0.6f, Color.red);
    }

    void CheckGround()
    {
        // Raycast
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.6f);
    }
}