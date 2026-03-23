using UnityEngine;

public class AddForceChain : MonoBehaviour
{
    public float pushForce = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float dir = Mathf.Sign(rb.linearVelocity.x);
        rb.AddForce(transform.right * dir * pushForce);
    }
}
