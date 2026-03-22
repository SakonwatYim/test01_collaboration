using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Transform targetObject; // object ที่จะขยับ
    public Vector3 moveOffset;     // ระยะที่ขยับ
    public float speed = 2f;

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool isPressed = false;
    

    void Start()
    {
        startPos = targetObject.position;
        targetPos = startPos + moveOffset;
    }

    void Update()
    {
        if (isPressed)
        {
            targetObject.position = Vector3.Lerp(targetObject.position, targetPos, Time.deltaTime * speed);
        }
        else
        {
            targetObject.position = Vector3.Lerp(targetObject.position, startPos, Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            isPressed = true;
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            isPressed = false;
        }
    }
}