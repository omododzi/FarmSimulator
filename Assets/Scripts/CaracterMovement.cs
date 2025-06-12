using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float runSpeed = 8f;
    public float rotateSpeed = 10f;
    
    [Header("Gravity Settings")]
    public float gravity = -9.81f;
    public float groundedGravity = -0.5f;
    
    private Vector3 velocity;
    private CharacterController controller;
    private Transform cameraTransform;
    
    [Header("Input Settings")]
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";
    public KeyCode runKey = KeyCode.LeftShift;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform; // Более надежный способ получить камеру
    }

    void Update()
    {
        HandleMovement();
        ApplyGravity();
        controller.Move(velocity * Time.deltaTime);
    }

    void HandleMovement()
    {
        // Получаем ввод
        float horizontalInput = Input.GetAxis(horizontalAxis);
        float verticalInput = Input.GetAxis(verticalAxis);
        
        // Создаем вектор направления ввода
        Vector2 inputDirection = new Vector2(horizontalInput, verticalInput);
        
        // Нормализуем, если длина больше 1
        if (inputDirection.magnitude > 1f)
        {
            inputDirection.Normalize();
        }
        
        // Получаем направление относительно камеры
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();
        
        // Рассчитываем направление движения
        Vector3 moveDirection = cameraForward * inputDirection.y + cameraRight * inputDirection.x;
        
        // Проверяем бег
        float currentSpeed = Input.GetKey(runKey) ? runSpeed : moveSpeed;
        Vector3 movement = moveDirection * currentSpeed;
        
        velocity.x = movement.x;
        velocity.z = movement.z;

        // Поворот персонажа
        if (inputDirection.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }

    void ApplyGravity()
    {
        if (controller.isGrounded)
        {
            velocity.y = groundedGravity;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
    }
}