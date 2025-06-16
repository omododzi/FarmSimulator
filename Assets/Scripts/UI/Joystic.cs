using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Joystic : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler

{
   
    [Header("Joystick Settings")]
    public float handleRange = 1f; // Максимальное расстояние ручки от центра
    public float deadZone = 0.2f;  // Минимальное значение для регистрации ввода
    
    [Header("References")]
    public RectTransform background; // Фон джойстика (большой круг)
    public RectTransform handle;     // Ручка джойстика (маленький круг)

    private Vector2 inputVector = Vector2.zero;
    private Canvas canvas;
    private Camera cam;

    public GameObject father;
    public GameObject othergo;

    public float Horizontal => inputVector.x;
    public float Vertical => inputVector.y;
    public Vector2 Direction => new Vector2(Horizontal, Vertical);
    private bool useMobile = false;

    private void Start()
    {
        CharacterMovement characterController = 
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();

        
        father.SetActive(characterController.useMobileInput);
        othergo.SetActive(characterController.useMobileInput);
        
        canvas = GetComponentInParent<Canvas>();
        cam = canvas.worldCamera;
        
        // Скрыть ручку, если не нажато
        handle.anchoredPosition = Vector2.zero;
    }

    public void LateUpdate()
    {
        CharacterMovement characterController = 
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
        father.SetActive(characterController.useMobileInput);
        othergo.SetActive(characterController.useMobileInput);
    }

    // При нажатии на джойстик
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
        
        CameraController cameraController = Camera.main.GetComponent<CameraController>();
        cameraController.canMove = false;
    }

    // При перемещении пальца/мыши
    public void OnDrag(PointerEventData eventData)
    {
        CameraController cameraController = Camera.main.GetComponent<CameraController>();
        cameraController.canMove = false;
        Debug.Log("OnPointerDown");
        Vector2 position;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            background, 
            eventData.position, 
            cam, 
            out position))
        {
            // Нормализуем позицию относительно размера фона
            position /= (background.sizeDelta * 0.5f);
            
            // Ограничиваем позицию внутри круга
            inputVector = (position.magnitude > 1f) ? position.normalized : position;
            
            // Применяем "мертвую зону" (если ввод слишком мал, игнорируем)
            if (position.magnitude < deadZone)
                inputVector = Vector2.zero;
            
            // Перемещаем ручку джойстика
            handle.anchoredPosition = inputVector * (background.sizeDelta * 0.5f * handleRange);
        }
    }

    // При отпускании джойстика
    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
        CameraController cameraController = Camera.main.GetComponent<CameraController>();
        cameraController.canMove = true;
    }
}
