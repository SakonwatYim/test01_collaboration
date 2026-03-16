using UnityEngine;

public class BallController : MonoBehaviour
{
    public float moveForce = 20f;
    public float maxSpeed = 10f;
    public float jumpForce = 7f;

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

        Vector3 direction = camForward * v + camRight * h;

        if (rb.linearVelocity.magnitude < maxSpeed)
        {
            rb.AddForce(direction * moveForce);
        }
        Debug.DrawRay(transform.position, Vector3.down * 0.6f, Color.red);
    }

    void CheckGround()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.6f);
    }
}