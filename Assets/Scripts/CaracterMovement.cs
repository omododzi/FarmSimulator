using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float runSpeed = 8f;
    public float rotateSpeed = 10f;
    public float acceleration = 5f;
    public float deceleration = 8f;
    
    [Header("Gravity Settings")]
    public float gravity = -9.81f;
    public float groundedGravity = -0.5f;
    
    [Header("Animation Settings")]
    public float walkAnimationThreshold = 0.1f; // Порог скорости для анимации ходьбы
    public float animationTransitionSpeed = 5f; // Скорость перехода между анимациями
    
    private Vector3 velocity;
    private CharacterController controller;
    private Transform cameraTransform;
    public Animator animator;
    private float currentSpeed;
    
    [Header("Input Settings")]
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";
    public KeyCode runKey = KeyCode.LeftShift;
    
    public bool canMove = true;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        if (canMove)
        {
            HandleMovement();
            controller.Move(velocity * Time.deltaTime);
        }
        else
        {
            controller.Move(Vector3.zero);
        }
        
        ApplyGravity();
        UpdateAnimations();
        
    }

    void HandleMovement()
    {
        // Получаем ввод
        float horizontalInput = Input.GetAxis(horizontalAxis);
        float verticalInput = Input.GetAxis(verticalAxis);
        
        // Создаем вектор направления ввода
        Vector2 inputDirection = new Vector2(horizontalInput, verticalInput);
        float inputMagnitude = Mathf.Clamp01(inputDirection.magnitude);
        
        // Получаем направление относительно камеры
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();
        
        // Рассчитываем направление движения
        Vector3 moveDirection = cameraForward * inputDirection.y + cameraRight * inputDirection.x;
        
        // Определяем скорость движения
        bool isRunning = Input.GetKey(runKey) && inputMagnitude > 0.1f;
        float targetSpeed = isRunning ? runSpeed : moveSpeed;
        targetSpeed *= inputMagnitude;
        
        // Плавное изменение скорости
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, 
            (targetSpeed > currentSpeed ? acceleration : deceleration) * Time.deltaTime);
        
        // Применяем движение
        if (inputMagnitude > 0.1f)
        {
            Vector3 movement = moveDirection * currentSpeed;
            velocity.x = movement.x;
            velocity.z = movement.z;
            
            // Поворот персонажа
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 
                rotateSpeed * Time.deltaTime);
        }
        else
        {
            // Плавное замедление
            velocity.x = Mathf.Lerp(velocity.x, 0, deceleration * Time.deltaTime);
            velocity.z = Mathf.Lerp(velocity.z, 0, deceleration * Time.deltaTime);
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

    void UpdateAnimations()
    {
        if (animator == null) return;
        
        // Определяем состояние движения
        bool isMoving = Mathf.Abs(velocity.x) > walkAnimationThreshold || 
                       Mathf.Abs(velocity.z) > walkAnimationThreshold;
        bool isRunning = Input.GetKey(runKey) && isMoving;
        
        // Устанавливаем значение Blend Tree
        float targetBlendValue = isRunning ? 1f : 0f;
        float currentBlendValue = animator.GetFloat("Blend");
        float newBlendValue = Mathf.Lerp(currentBlendValue, targetBlendValue, 
            animationTransitionSpeed * Time.deltaTime);
        
        animator.SetFloat("Blend", newBlendValue);
        
        // Дополнительный параметр для полной остановки (опционально)
        animator.SetBool("iswalk", isMoving);
    }
}