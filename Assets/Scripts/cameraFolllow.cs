using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollower : MonoBehaviour
{
    public Transform target;

    // กล้องแต่ละมุม
    public Vector3[] offsets;
    private int currentView = 0;

    void Update()
    {
        // สลับมุมกล้องเมื่อกด C
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            currentView++;
            if (currentView >= offsets.Length)
                currentView = 0;
        }

        // ตามรถ
        transform.position = target.position + offsets[currentView];

        // ให้กล้องมองไปที่รถเสมอ
        transform.LookAt(target);
    }
}
