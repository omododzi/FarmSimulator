using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    public Vector3 offset = new Vector3(0f, 2f, -5f);
    
    [Header("Follow Settings")]
    public float distanceFromTarget = 5f;
    public float minVerticalAngle = -20f;
    public float maxVerticalAngle = 80f;
    
    [Header("Rotation Settings")]
    [Range(0.1f, 5f)]
    public float rotationSpeed = 1f;
    public float mouseSensitivity = 2f;
    
    [Header("Smoothing")]
    [Range(0.01f, 0.5f)]
    public float positionSmoothTime = 0.1f;
    
    public float lookAtHeightOffset = 0.5f;
    
    private Vector3 velocity = Vector3.zero;
    private bool targetFound = false;
    private float currentX = 0f;
    private float currentY = 0f;

    void Start()
    {
        FindTarget();
        // Инициализируем углы камеры
        Vector3 angles = transform.eulerAngles;
        currentX = angles.y;
        currentY = angles.x;
    }

    void LateUpdate()
    {
        if (!targetFound || target == null)
        {
            FindTarget();
            return;
        }
        
        HandleCameraRotation();
        FollowTarget();
    }
    
    private void FindTarget()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
            targetFound = true;
            
            // Устанавливаем начальную позицию камеры
            transform.position = target.position + offset;
            transform.LookAt(target.position + Vector3.up * lookAtHeightOffset);
        }
    }

    private void HandleCameraRotation()
    {
        if (Input.GetMouseButton(0)) // ПКМ зажата
        {
            currentX += Input.GetAxis("Mouse X") * mouseSensitivity;
            currentY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            
            // Ограничиваем вертикальный угол
            currentY = Mathf.Clamp(currentY, minVerticalAngle, maxVerticalAngle);
        }
    }

    private void FollowTarget()
    {
        if (target == null) return;
        
        // Рассчитываем новую позицию камеры
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 desiredPosition = target.position + 
                                rotation * new Vector3(0, 0, -distanceFromTarget);
        
        // Плавное перемещение
        transform.position = Vector3.SmoothDamp(
            transform.position,
            desiredPosition,
            ref velocity,
            positionSmoothTime
        );
        
        // Всегда смотрим на цель с учетом смещения по высоте
        transform.LookAt(target.position + Vector3.up * lookAtHeightOffset);
    }
}