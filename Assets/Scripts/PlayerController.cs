// Lecture Note
// [1] New Input System in Unity: https://learn.unity.com/tutorial/getting-started-with-the-new-input-system

using UnityEngine;
using UnityEngine.InputSystem;

public class AdvancePlayerController : MonoBehaviour
{
    // [1] Define the car settings ��駤��ö

    [Header("Car Settings")]
    public float maxSpeed = 20.0f;
    public float acceleration = 10.0f;
    public float deceleration = 15.0f;
    public float turnSpeed = 180.0f;
    public float brakingForce = 20.0f;

    // [2] Define the current state of the car
    [Header("Current State")]
    private float currentSpeed = 0.0f;
    private float horInput = 0;
    private float verInput = 0;
    private bool isBraking = false;

    void Update()
    {
        // [3] Get input values �Ӥ��input���
        InputAction moveAction = InputSystem.actions.FindAction("Move");
        //InputAction ����� moveAction ���͵���� InputSystem �繤��� .actions ���¡������ .FindAction("Move") �����¡�����move
        Vector2 input = moveAction.ReadValue<Vector2>();
        // �׹��ҡ�Ѻ�ҵ���õ��᡹ x y input���͵����
        horInput = input.x;
        verInput = input.y;

        // [4] Handle braking
        isBraking = Input.GetKey(KeyCode.Space);

        // [5] Apply acceleration/deceleration �ӹǳ�������� �ѵ�����Ǥٳ����
        // and Calculate currentSpeed
        if (verInput != 0) //verInput -1,1
        {
            // [6] Apply acceleration to currentSpeed
            // v = u + at �������ǻѨ�غѹ = verInput * ������� * ����
            currentSpeed += verInput * acceleration * Time.deltaTime;
        }
        else
        {
            // [7] Natural deceleration when no input  verInput ��� 0 
            // ��������� * ���� �������ç������Ҩ�ԧ
            var decelAmount = deceleration * Time.deltaTime;
            // 
            if (Mathf.Abs(currentSpeed) <= decelAmount)
            {
                currentSpeed = 0;
            }
            else
            {
                //������������Ŵŧ������� 
                currentSpeed -= Mathf.Sign(currentSpeed) * decelAmount;
            }
        }

        // [8] Apply braking
        if (isBraking)
        {

        }

        // [9] Clamp speed �ӡѴ�������� Mathf.Clamp�����觷���������ش����٧�ش
        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);



        // [10] **Apply movement** �����ö��Ѻ�¡������¹���
        transform.Translate(currentSpeed * Time.deltaTime * Vector3.forward);

        // [11] Apply steering (only when moving)

        if (Mathf.Abs(currentSpeed) > Mathf.Epsilon)
        {
            transform.Rotate(Vector3.up, turnSpeed * horInput * Time.deltaTime);
        }
    }
}
