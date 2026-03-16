using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class cameraFollow : MonoBehaviour
{
    public Transform target;      // ลูกบอล
    public float distance = 5f;   // ระยะกล้อง
    public float mouseSensitivity = 200f;
    public float yRotation = 0f;
    public float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -40f, 60f);

        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0);

        Vector3 position = target.position - (rotation * Vector3.forward * distance);

        transform.position = position;
        transform.LookAt(target);
    }
}